/**
要求：
   1. 采用后插建立链表法创建一个包含n（n>0）个结点的链表，结点个数n及各结点成员的值均由键盘输入。请使用动态链表实现，否则不得分。
   2. 输出各结点中info和grade成员的值，见测试数据。
   3. (提示：考试系统中使用scanf函数，但不能使用scanf_s;主函数使用int main(){return 0;}) vs2015之前版本形式，但不能使用void main(){}。）
*/
#include <stdio.h>
#include <stdlib.h>
struct node
{
    char info[20];
    int grade[2];
    struct node *next;
};

typedef struct node Node;

// 申请一个链表节点,并且初始化
Node *InitListNode(char info[20], int gradeA, int gradeB)
{
    Node *newNode = (Node *)malloc(sizeof(Node));
    for (int i = 0; i < 20; i++)
    {
        newNode->info[i] = info[i];
    }
    newNode->grade[0] = gradeA;
    newNode->grade[1] = gradeB;
    newNode->next = NULL;
    return newNode;
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
        int gradeA, gradeB;
        scanf("%s %d %d", info, &gradeA, &gradeB);
        Node *newNode = InitListNode(info, gradeA, gradeB);
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
        printf("%s:%d %d\n", cur->info, cur->grade[0], cur->grade[1]);
        cur = cur->next;
    }
}

int main(int argc, char const *argv[])
{
    printf("输入数据为:\n");
    int size = 0;
    scanf("%d", &size);
    Node *head = CreateListNode(size);
    printf("输出结果为:\n");
    PrintListNode(head);
    return 0;
}
