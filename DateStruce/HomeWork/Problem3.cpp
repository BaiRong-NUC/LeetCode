/**
要求：
    1. 采用后插建立链表法创建一个包含n个结点的链表，结点个数n及各结点成员的值均由键盘输入。说明：输入数据时，各结点成员值按grade值从小到大的顺序初始化。
    2. 输入待插入结点成员的值，并将该结点有序插入到链表中，最后输出各结点info和no成员的值，输出格式见测试数据。
    3. 请使用动态链表实现，否则不得分。 (提示：考试系统中使用scanf函数，但不能使用scanf_s;主函数使用int main(){return 0;}形式，但不能使用void main(){}。)
 */
#include <stdio.h>
#include <stdlib.h>
#include <limits.h>
struct node
{
    char info[20];
    int no;
    int grade;
    struct node *next;
};

typedef struct node Node;

// 申请一个链表节点,并且初始化,初始化节点是有序的
Node *InitListNode(char info[20], int no, int grade)
{
    Node *newNode = (Node *)malloc(sizeof(Node));
    for (int i = 0; i < 20; i++)
    {
        newNode->info[i] = info[i];
    }
    newNode->no = no;
    newNode->grade = grade;
    newNode->next = NULL;
    return newNode;
}

// 插入一个节点,并保证链表有序,传入用户输入的节点信息
// head是二级指针,因为可能会修改头指针 head不带头
void InsertListNode(Node **head, char info[20], int no, int grade)
{
    // 申请空间
    Node *newNode = InitListNode(info, no, grade);
    // 有序的插入到head链表中

    // 加头节点,方便插入
    Node *dummyHead = (Node *)malloc(sizeof(Node));
    dummyHead->grade = INT_MIN; // 头节点设置为最小值
    dummyHead->next = *head;
    Node *cur = dummyHead;
    Node *prev = NULL; // 前驱节点
    while (cur != NULL)
    {
        if (cur->grade > grade)
        {
            // 新节点插入到prev和cur之间
            prev->next = newNode;
            newNode->next = cur;

            // 判断是不是头节点
            if (cur == *head)
            {
                // 头插
                *head = newNode; // 更新头指针
            }
            break;
        }
        prev = cur;
        cur = cur->next;
    }

    // 如果遍历完都没有插入,说明新节点是最大的,插入到最后
    // 尾插
    if (cur == NULL)
    {
        prev->next = newNode;
        newNode->next = NULL;
        if (*head == NULL)
        {
            *head = newNode; // 更新头指针
        }
    }
}

// 创建链表
Node *CreateListNode(int size)
{
    // 创建头节点,方便计算
    Node *head = (Node *)malloc(sizeof(Node));
    head->next = NULL;
    Node *tail = head; // 尾指针
    for (int i = 0; i < size; i++)
    {
        char info[20];
        int no, grade;
        scanf("%s %d %d", info, &no, &grade);
        Node *newNode = InitListNode(info, no, grade);
        // 尾插法
        tail->next = newNode; // 尾插法
        tail = newNode;       // 更新尾指针
    }

    // 头节点删掉
    Node *temp = head;
    head = head->next;
    free(temp);

    return head;
}

// 按照格式打印链表
void PrintListNode(Node *head)
{
    if (head == NULL)
    {
        printf("链表为空!\n");
        return;
    }
    Node *cur = head;
    while (cur != NULL)
    {
        printf("%s:%d %d->", cur->info, cur->no, cur->grade);
        cur = cur->next;
    }
}

int main(int argc, char const *argv[])
{
    printf("输入数据为:\n");
    int size = 0;
    scanf("%d", &size);
    if (size < 0)
    {
        printf("输入数据有误!\n");
        return 0;
    }
    Node *head = CreateListNode(size);
    char info[20];
    int no = 0, grade = 0;
    scanf("%s %d %d", info, &no, &grade);
    InsertListNode(&head, info, no, grade);
    printf("输出结果为:\n");
    PrintListNode(head);
    return 0;
}