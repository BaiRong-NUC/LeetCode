#include "./SharedPtr.h"

int main(int argc, char const *argv[])
{
    // 拷贝,赋值
    SharedPtr<int> p = SharedPtr<int>(new int(10));
    printf("use_count=%d, ptr=%p\n", p.use_count(), p.get());
    {
        SharedPtr<int> p2 = p;
        printf("use_count=%d, ptr=%p\n", p2.use_count(), p2.get());
    }
    printf("use_count=%d, ptr=%p\n", p.use_count(), p.get());

    printf("----------------------\n");
    // 移动拷贝,移动赋值
    SharedPtr<int> p3 = SharedPtr<int>(new int(20));
    printf("use_count=%d, ptr=%p\n", p3.use_count(), p3.get());
    {
        SharedPtr<int> p4 = std::move(p3);
        printf("use_count=%d, ptr=%p\n", p4.use_count(), p4.get());
    }
    printf("use_count=%d, ptr=%p\n", p3.use_count(), p3.get());
    return 0;
}
