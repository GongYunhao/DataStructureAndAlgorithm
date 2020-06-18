using System;
using System.Text;
using CommonModels;

namespace Offer
{
    public class SerializeBinaryTree
    {
        public static string Serialize(BinaryTreeNode<int> root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));

            StringBuilder sb = new StringBuilder();
            SerializeRecursively(root, sb);
            return sb.ToString(0, sb.Length - 1);
        }

        private static void SerializeRecursively(BinaryTreeNode<int> root, StringBuilder sb)
        {
            if (root == null)
            {
                sb.Append("$,");
                return;
            }

            sb.Append(root.Value).Append(",");
            SerializeRecursively(root.Left, sb);
            SerializeRecursively(root.Right, sb);
        }

        public static BinaryTreeNode<int> Deserialize(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text), "");

            // 转换的最小情形是一个单节点的二叉树,所以字符串数组最小的元素数量为3
            string[] array = text.Split(',');
            if (array.Length < 3)
                return null;

            int index = -1;

            BinaryTreeNode<int> result;
            try
            {
                result = DeserializeRecursively(array, ref index);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new ArgumentException("The given string can't be converted to binary tree", e);
            }

            // 正常情况下,循环结束时index应当指向array数组的最后一个元素
            // 如果index超出界限,说明字符串缺少一定数量的$;如果index未达到界限,说明在序列化的结果后又追加了无用的字符串
            if (index != array.Length - 1)
                throw new ArgumentException("The given string can't be converted to binary tree");

            return result;
        }

        private static BinaryTreeNode<int> DeserializeRecursively(string[] array, ref int index)
        {
            // index从-1开始,每次循环都先移动,再读取对应的元素
            index++;

            if (index >= array.Length)
                throw new IndexOutOfRangeException("The index is out of array count, maybe loss '$' in the string");

            if (array[index] == "$")
                return null;

            BinaryTreeNode<int> root = new BinaryTreeNode<int>(int.Parse(array[index]));
            root.Left = DeserializeRecursively(array, ref index);
            root.Right = DeserializeRecursively(array, ref index);
            return root;
        }
    }
}
