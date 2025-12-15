/**
    社团共有 num 位成员参与破冰游戏，编号为 0 ~ num-1。成员们按照编号顺序围绕圆桌而坐。
    社长抽取一个数字 target，从 0 号成员起开始计数，排在第 target 位的成员离开圆桌，且成员离开后从下一个成员开始计数。
    请返回游戏结束时最后一位成员的编号。
*/
public class Solution
{
    public int IceBreakingGame(int num, int target)
    {
        int ans = 0; // 只有 1 个人时，最后剩下的成员编号为 0
        // 从 2 个人开始推导到 num 个人
        for (int i = 2; i <= num; i++)
        {
            // 公式：f(n) = (f(n-1) + m) % n  f(n-1) + m 代表上一轮的结果加上当前的步长
            // 这里 i 代表当前的人数,ans 代表上一轮(i-1个人)的结果
            ans = (ans + target) % i;
        }
        return ans;
    }
}