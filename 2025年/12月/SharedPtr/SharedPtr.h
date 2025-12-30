#include <iostream>
#include <atomic>
#include <utility>
using namespace std;
template <typename T>
class SharedPtr
{
private:
    T *_ptr;
    std::atomic<int> *_refCount;

    // 原子操作引用计数
    int _addRef()
    {
        return _refCount ? _refCount->fetch_add(1) + 1 : 0;
    }
    int _releaseRef()
    {
        return _refCount ? _refCount->fetch_sub(1) - 1 : 0;
    }

    void _destroy()
    {
        if (this->_ptr != nullptr && this->_releaseRef() == 0)
        {
            delete this->_ptr;
            this->_ptr = nullptr;
            delete this->_refCount;
            this->_refCount = nullptr;
        }
    }

public:
    // 普通构造
    SharedPtr(T *ptr = nullptr) : _ptr(ptr), _refCount(ptr ? new std::atomic<int>(1) : nullptr) {}

    // 拷贝构造
    SharedPtr(const SharedPtr &other) : _ptr(other._ptr), _refCount(other._refCount)
    {
        // 增加引用计数
        if (this->_ptr != nullptr)
            this->_addRef();
    }

    // 赋值
    SharedPtr &operator=(const SharedPtr &other)
    {
        if (this != &other)
        {
            // 指向其他对象，先销毁自己
            this->_destroy();
            this->_ptr = other._ptr;
            this->_refCount = other._refCount;
            if (this->_ptr != nullptr)
                this->_addRef(); // 增加引用计数
        }
        return *this;
    }

    // 移动拷贝 ,exchange后,other对象调用析构时_destroy直接返回,引用计数不需要改变
    SharedPtr(SharedPtr &&other) : _ptr(std::exchange(other._ptr, nullptr)),
                                   _refCount(std::exchange(other._refCount, nullptr)) {}

    // 移动赋值
    SharedPtr &operator=(SharedPtr &&other)
    {
        if (this != &other)
        {
            // 指向其他对象，先销毁自己
            this->_destroy();
            this->_ptr = std::exchange(other._ptr, nullptr);
            this->_refCount = std::exchange(other._refCount, nullptr);
        }
        return *this;
    }

    ~SharedPtr()
    {
        this->_destroy();
    }

    int use_count() const { return _refCount ? _refCount->load() : 0; }

    T *get() const
    {
        return this->_ptr;
    }
};
