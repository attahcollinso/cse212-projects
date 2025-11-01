public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;

        ////////////////////////////////////////////////////////////////////////////////
        // PLAN / PROCESS (steps written as comments BEFORE the code)
        //
        // 1. Clarify inputs and output:
        //    - Inputs:
        //        a) startingNumber (double) — the base number whose multiples we want.
        //        b) count (int) — the number of multiples to generate.
        //    - Output: double[] containing count multiples: startingNumber * 1, *2, ..., *count.
        //
        // 2. Consider edge cases:
        //    - If count <= 0: return an empty array.
        //    - startingNumber may be 0, negative, or fractional — treat normally.
        //    - Avoid integer overflow by using double for output (per requirement).
        //
        // 3. Choose algorithm:
        //    - Allocate a double array of length count (if count > 0).
        //    - Loop index i from 0 to count-1.
        //    - Compute multiple = startingNumber * (i + 1).
        //    - Store multiple into result[i].
        //
        // 4. Complexity:
        //    - Time: O(count) — single pass to fill the array.
        //    - Space: O(count) — returned array of size count.
        //
        // 5. Testing plan (examples to check after implementation):
        //    - MultiplesOf(3, 5)  => {3, 6, 9, 12, 15}
        //    - MultiplesOf(2.5, 4)=> {2.5, 5.0, 7.5, 10.0}
        //    - MultiplesOf(0, 3)  => {0, 0, 0}
        //    - MultiplesOf(5, 0)  => {}   (empty)
        // Implementation removed as it was a duplicate of the solution
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {

        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN / PROCESS (written in comments before the code)
        //
        // 1. Clarify inputs and outputs:
        //    - Input: data (List<int>) and amount (int) where 1 <= amount <= data.Count.
        //    - Output: none (the input list 'data' is modified in-place so that elements are rotated right).
        //
        // 2. Edge cases:
        //    - If data is null -> throw ArgumentNullException.
        //    - If data.Count <= 1 -> nothing to do (list of length 0 or 1 is the same after rotation).
        //    - If amount % data.Count == 0 -> rotation by a multiple of the list length leaves the list unchanged.
        //    - Normalize amount to amount % data.Count to handle any unexpected values (defensive).
        //
        // 3. Choose algorithm (in-place, O(n) time, O(1) extra space):
        //    - Use the three-reverse method to rotate in-place:
        //        a) Reverse the entire list.
        //        b) Reverse the first 'amount' elements.
        //        c) Reverse the remaining elements (from amount to end).
        //    - Example: data = [1,2,3,4,5,6,7,8,9], amount = 3
        //        a) reverse all => [9,8,7,6,5,4,3,2,1]
        //        b) reverse first 3 => [7,8,9,6,5,4,3,2,1]
        //        c) reverse rest => [7,8,9,1,2,3,4,5,6]
        //
        // 4. Implementation details:
        //    - Implement a helper that reverses a portion of the list in-place given start and end indices.
        //    - Use 0-based indexing. The first 'amount' elements correspond to indices [0, amount-1].
        //    - Be careful to handle inclusive/exclusive bounds consistently.
        //
        // 5. Complexity:
        //    - Time: O(n) (each element is moved at most a constant number of times).
        //    - Space: O(1) additional space (in-place).
        //
        // 6. Tests to run after implementation:
        //    - Normal: [1..9], amount=3 => [7,8,9,1,2,3,4,5,6]
        //    - amount == data.Count => unchanged
        //    - amount == 1 => last element moves to front
        //    - data has negative/duplicate values => rotation unaffected
        //    - data.Count == 0 or 1 => unchanged
        //

        // Start of implementation

        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        int n = data.Count;

        // Nothing to do for empty or single-element lists
        if (n <= 1)
        {
            return;
        }

        // Defensive: normalize amount in case the caller passes an amount equal to n (or larger)
        // The problem statement guarantees 1 <= amount <= data.Count, but normalizing is safe and general.
        amount = amount % n;
        if (amount == 0)
        {
            // rotating by a multiple of n results in the same list
            return;
        }

        // Helper local function: reverse elements in data between indices 'start' and 'end' (inclusive)
        void ReverseRange(List<int> list, int start, int end)
        {
            while (start < end)
            {
                int tmp = list[start];
                list[start] = list[end];
                list[end] = tmp;
                start++;
                end--;
            }
        }

        // 1) Reverse the entire list
        ReverseRange(data, 0, n - 1);

        // 2) Reverse the first 'amount' elements (indices 0 .. amount-1)
        ReverseRange(data, 0, amount - 1);

        // 3) Reverse the remaining elements (indices amount .. n-1)
        ReverseRange(data, amount, n - 1);

        // End of implementation
    }
}
