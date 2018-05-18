using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Factorization;
using System.Globalization;

namespace RSA_Project.Controllers
{
    public class Program
    {
        public int SVD(double [,] A, double[,] B) {  
        //Matrix mat = new Matrix();

            //int min = 0;
            //if (A.GetLength(0) > A.GetLength(1)) min = A.GetLength(1);
            //else min = A.GetLength(0);

            var matrix = DenseMatrix.OfArray(A);        

            var svd = matrix.Svd();

            var reconstruct = svd.U * svd.W * svd.VT;       

            double[,] U = new double[A.GetLength(1), A.GetLength(1)];
            for (int i = 0; i < A.GetLength(1); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    U[i, j] = svd.U[i, j];              // U matritsani topib olamiz
                }
            }

            double[,] V = new double[A.GetLength(1), A.GetLength(1)];
            for (int i = 0; i < A.GetLength(1); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    V[i, j] = svd.VT[j, i];         // Vmatritsani topib olamiz
                }
            }

            Hesh h = new Hesh();                // heshni obyektini yaratamiz
            h.U(U);
            h.V(V);
            double result = h.Hesh_Calc(U, V, B);           //resultga h qiymatni qabul qilamiz

            return Convert.ToInt32(result);
        }
    }
}