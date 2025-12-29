namespace Sort
{
    public class Solution
    {
        #region 快速排序
        private void _QuickSort(int[] nums, int left, int right)
        {
            if (left >= right) return;
            int pivxot = nums[left];
            while (left < right)
            {
                // 挖坑法
                while (left < right && nums[right] >= pivxot) right--;
                nums[left] = nums[right];
                while (left < right && nums[left] <= pivxot) left++;
                nums[right] = nums[left];
            }
            nums[left] = pivxot;
            _QuickSort(nums, 0, left - 1);
            _QuickSort(nums, left + 1, right);
        }
        public int[] QuickSort(int[] nums)
        {
            _QuickSort(nums, 0, nums.Length - 1);
            return nums;
        }
        #endregion

        # region 归并排序
        private int[] _Merge(int[] leftArr, int[] rightArr)
        {
            int[] array = new int[leftArr.Length + rightArr.Length];
            int leftBegin = 0;
            int rightBegin = 0;
            int index = 0;
            while (leftBegin < leftArr.Length && rightBegin < rightArr.Length)
            {
                if (leftArr[leftBegin] <= rightArr[rightBegin])
                {
                    array[index++] = leftArr[leftBegin++];
                }
                else
                {
                    array[index++] = rightArr[rightBegin++];
                }
            }
            while (leftBegin < leftArr.Length)
            {
                array[index++] = leftArr[leftBegin++];
            }
            while (rightBegin < rightArr.Length)
            {
                array[index++] = rightArr[rightBegin++];
            }
            return array;
        }
        private int[] _MergeSort(int[] nums, int left, int right)
        {
            if (left > right) return [];
            if (left == right) return new int[] { nums[left] };
            int mid = left + (right - left) / 2;
            int[] leftArr = _MergeSort(nums, left, mid); // [left,mid]
            int[] rightArr = _MergeSort(nums, mid + 1, right); // [mid+1,right]
            // 合并两个有序数组
            return _Merge(leftArr, rightArr);
        }
        // 归并排序
        public int[] MergeSort(int[] nums)
        {
            return _MergeSort(nums, 0, nums.Length - 1);
        }
        # endregion
    }
}