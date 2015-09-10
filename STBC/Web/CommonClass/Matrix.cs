using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.CommonClass
{
    /// <summary>
    /// 权重计算类，负责计算效益矩阵权重、适宜性权重，调用的方法为 CalcWeight(double[,] PdArray1,ref bool isok)，其它方法不用管。只要传入相关矩阵就行
    /// </summary>
    public class Matrix
    {
        private static int matrixnumber = 0;
        private int hashcode;
        /// 存储矩阵数据的二维数组
        internal protected double[,] Mat;
        private int row;
        /// 矩阵实际的列数
        private int col;
        /// 获取矩阵行数的属性，用于获得矩阵的行数
        public int Row
        {
            get
            {
                return this.row;
            }
        }
        /// 获取矩阵列数的属性，用于获得矩阵的列数
        /// </summary>
        public int Col
        {
            get
            {
                return this.col;
            }
        }
        public static double[,] CalcWeight(double[,] PdArray1,ref bool isok)
        {
            double esp = 0.0001;
            int weishu1 = 4;
            double eigvalue1;
            double[,] tzxl1;
            bool yzx1;

            Matrix mtx1 = new Matrix();
            //double[,] PdArray1 = new double[,] { { 1.0, 1.1111, 1.16, 1.45 }, { 0.9000, 1.0, 1.04, 1.3 }, { 0.8620, 0.9615, 1.0, 1.25 }, { 0.6896, 0.7692, 0.8, 1.0 } };
            //double[,] PdArray2 = new double[,] { { 1.0, 1.5534, 0.9295, 0.6575, 0.6103 }, { 0.6437, 1.0, 0.5984, 0.4233, 0.3929 }, { 1.0758, 1.6711, 1.0, 0.7074, 0.6567 }, { 1.5209, 2.3623, 1.4136, 1.0, 0.9282 }, { 1.6385, 2.5451, 1.5227, 1.0773, 1.0 } };

            weishu1 = (int)System.Math.Sqrt(PdArray1.Length);
            tzxl1 = mtx1.EigPower(PdArray1, esp, out eigvalue1);
            yzx1 = Matrix.yzxjy(eigvalue1, weishu1);
            if (yzx1 == false)
            {
                isok = yzx1;
                return null;
            }
            else
            {
                isok = yzx1;

                //归一化
                double a = 0;
                for (int i = 0; i < weishu1; i++)
                {
                    a = a + tzxl1[i, 0];
                }
                for (int i = 0; i < weishu1; i++)
                {
                    tzxl1[i, 0] = tzxl1[i, 0] / a;
                }
                return tzxl1;

            }
        }

        //一致性检验
        public static bool yzxjy(double tzz, int weishu)
        {
            double[] RI = { 0, 0, 0.52, 0.89, 1.12, 1.26, 1.36, 1.41, 1.46 };
            double CI = (tzz - weishu) / (weishu - 1);
            double CR = CI / RI[weishu];
            if (CR < 0.1)
                return true;
            else
                return false;
        }

        /// 构造函数2：用于产生一个指定行数和列数的矩阵，如果
        /// <param name="row">指定的行数</param>
        /// <param name="col">指定的列数</param>
        public Matrix(int row, int col)
        {
            //if (row <= 0 || col <= 0) throw new MatrixException("");
            Mat = new double[row, col];
            this.row = row;
            this.col = col;
            this.hashcode = Matrix.matrixnumber;
            Matrix.matrixnumber++;
        }
        /// 克隆矩阵
        /// <param name="mat2">被克隆矩阵</param>
        /// <returns>一个与mat2一样的矩阵</returns>
        /// <remarks>所谓克隆就是一份完整的拷贝</remarks>
        public static Matrix Clone(Matrix mat2)
        {
            Matrix mat1 = new Matrix(mat2.Row, mat2.Col);
            for (int i = 0; i < mat2.Row; i++)
                for (int j = 0; j < mat2.Col; j++)
                    mat1.Mat[i, j] = mat2.Mat[i, j];
            return mat1;
        }
        /// 二维double型数组隐式转换为矩阵
        /// <param name="mat2">二维数组</param>
        /// <returns>与数组同型的一个矩阵</returns>
        public static implicit operator Matrix(double[,] mat2)
        {
            Matrix mat1 = new Matrix(mat2.GetLength(0), mat2.GetLength(1));
            for (int i = 0; i < mat1.Row; i++)
                for (int j = 0; j < mat1.Col; j++)
                    mat1.Mat[i, j] = mat2[i, j];
            return mat1;
        }
        /// 两矩阵对应列作内积，要求两矩阵同型。
        /// <param name="mat1">矩阵1</param>
        /// <param name="mat2">矩阵2</param>
        /// <remarks>得到一行向量，其维数是和两矩阵的列数</remarks>
        public static Matrix Dot(Matrix mat1, Matrix mat2)
        {
            Matrix mat = new Matrix(1, mat1.Col);   //分配新的行矩阵（只含1行）
            double sum;
            for (int i = 0; i < mat.Col; i++)
            {
                sum = 0.0;      //求和变量，置0
                for (int j = 0; j < mat1.Row; j++)
                    sum += (mat1.Mat[j, i] * mat2.Mat[j, i]);
                mat.Mat[0, i] = sum;
            }
            return mat;
        }
        /// 返回n阶单位方阵
        /// <param name="n">方阵的阶数</param>
        public static Matrix Eye(int n)
        {
            Matrix mat = new Matrix(n, n);
            for (int i = 0; i < n; i++)
                mat.Mat[i, i] = 1;
            return mat;
        }


        /// <summary>
        /// 矩阵指定列向量的Inf范数
        /// <param name="Colnum">指定列</param>
        public double NormInf(int Colnum)
        {
            double vv = double.NegativeInfinity;   //把vv赋值为负无穷大
            for (int i = 0; i < this.Row; i++)
            {
                double vv2 = Math.Abs(Mat[i, Colnum]);
                if (vv2 > vv)
                    vv = vv2;
            }
            return vv;
        }
        /// 两矩阵相减
        /// </summary>
        public static Matrix operator -(Matrix mat1, Matrix mat2)
        {
            Matrix mat = new Matrix(mat1.Row, mat1.Col);
            for (int i = 0; i < mat1.Row; i++)
                for (int j = 0; j < mat1.Col; j++)
                    mat.Mat[i, j] = mat1.Mat[i, j] - mat2.Mat[i, j];
            return mat;
        }
        /// 矩阵右乘一个数
        public static Matrix operator *(double lamda, Matrix mat2)
        {
            Matrix mat1 = new Matrix(mat2.Row, mat2.Col);
            for (int i = 0; i < mat1.Row; i++)
                for (int j = 0; j < mat1.Col; j++)
                    mat1.Mat[i, j] = mat2.Mat[i, j] * lamda;
            return mat1;
        }
        /// 矩阵左除一个数
        public static Matrix operator /(Matrix mat2, double lamda)
        {
            return (1.0 / lamda) * mat2;
        }
        /// 存取指定行指定列的矩阵元素或按行计数存取指定位置的元素
        /// 对于存取指定行指定列的矩阵元素这种情况，就是一般的存和取。对于
        /// 按行计数存取指定位置的元素的情况，
        public double this[int rownum, int colnum]
        {
            get
            {
                if (colnum >= 0) return this.Mat[rownum, colnum];
                else
                {
                    int j = rownum % this.Col;
                    int i = (rownum - j) / this.Col;
                    return this.Mat[i, j];
                }
            }
            set
            {
                if (colnum >= 0)
                    this.Mat[rownum, colnum] = value;
                else
                {
                    int j = rownum % this.Col;
                    int i = (rownum - j) / this.Col;
                    this.Mat[i, j] = value;
                }
            }
        }

        /// 两矩阵相乘
        public static Matrix operator *(Matrix mat1, Matrix mat2)
        {
            Matrix mat = new Matrix(mat1.Row, mat2.Col);
            for (int i = 0; i < mat1.Row; i++)
                for (int j = 0; j < mat2.Col; j++)
                {
                    double sum = 0.0;
                    for (int k = 0; k < mat1.Col; k++)
                    {
                        sum += mat1.Mat[i, k] * mat2.Mat[k, j];
                    }
                    mat.Mat[i, j] = sum;
                }
            return mat;
        }

        /// <summary>
        /// 构造函数1：用于产生一个0行0列的矩阵
        /// </summary>
        public Matrix()
        {
            Mat = new double[0, 0];
            this.col = this.row = 0;
            this.hashcode = Matrix.matrixnumber;
            Matrix.matrixnumber++;
        }
        /// 用乘幂法求实方阵的最大特征值及其特征向量
        /// <param name="A">待求特征值及特征向量的矩阵</param>
        /// <param name="vv0">初始化列向量（列矩阵）</param>
        /// <param name="epsl">算法精度</param>
        /// <param name="eigvalue">求出的最大特征值</param>
        public double[,] EigPower(Matrix A, double epsl, out double eigvalue)
        {
            double[,] vv9 = { { 1 }, { 1 }, { 1 }, { 1 } };

            //设置存放
            double[,] vv = new double[A.Col, 1];
            for (int i = 0; i < A.Col; i++)
            {
                vv[i, 0] = 1;
            }

            Matrix vv0 = (Matrix)vv;
            Matrix v0 = Matrix.Clone(vv0);//为了不造成vv0被改变，克隆至v0
            Matrix u1 = A * v0;
            Matrix v1 = u1 / (u1.NormInf(0));
            Matrix u0 = A * v1;
            v0 = u0 / u0.NormInf(0);
            bool IsOdd = true;
            while (true)
            {
                if (IsOdd)
                {
                    u1 = A * v0;
                    v1 = u1 / u1.NormInf(0);
                    IsOdd = false;
                }
                else
                {
                    u0 = A * v1;
                    v0 = u0 / u0.NormInf(0);
                    IsOdd = true;
                }
                Matrix u = (u0 - u1);
                if (u.NormInf(0) <= epsl)
                {
                    if (IsOdd)
                    {
                        if (Matrix.Dot(v0, v1).Mat[0, 0] > 0)
                            eigvalue = u0.NormInf(0);
                        else
                            eigvalue = -(u0.NormInf(0));
                        return u1.Mat;
                    }
                    else
                    {
                        if (Matrix.Dot(v0, v1).Mat[0, 0] > 0)
                            eigvalue = u0.NormInf(0);
                        else
                            eigvalue = -(u0.NormInf(0));
                        return u0.Mat;
                    }
                }
            }
        }
    }
}
