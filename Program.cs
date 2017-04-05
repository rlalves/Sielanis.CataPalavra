using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Estudo.Cc01
{
    class Program
    {
        public static int Randomico
        {
            get
            {
                return DateTime.Now.Millisecond + DateTime.Now.Second + DateTime.Now.Minute;
            }
        }

        private static int totalDeLinhas = 10;
        private static int totalDeColunas = 15;
        private static char[,] grid = new char[totalDeLinhas, totalDeColunas];
        private static bool[,] gridUsado = new bool[totalDeLinhas, totalDeColunas];
        private static List<char> letras = new List<char>();

        static void Main(string[] args)
        {
            try
            {
                string p1 = Console.ReadLine();
                string p2 = Console.ReadLine();
                string p3 = Console.ReadLine();
                string p4 = Console.ReadLine();
                string p5 = Console.ReadLine();

                PopulaLetras();

                AdicionaLetras(p1);
                AdicionaLetras(p2);
                AdicionaLetras(p3);
                AdicionaLetras(p4);
                AdicionaLetras(p5);

                InserePalavraHorizontal(p1);
                InserePalavraHorizontal(p2);
                InserePalavraHorizontal(p3);
                InserePalavraHorizontal(p4);
                InserePalavraVertical(p5);

                PopulaGrid();
                ExibeGridLetras();
                Console.WriteLine();
                Console.WriteLine();
                ExibeGabarito();

                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro:" + ex.Message);
                Console.Read();
            }
        }

        static private void AdicionaLetras(string p)
        {
            try
            {
                for (int i = 0; i < p.Length; i++)
                    letras.Add(Convert.ToChar(p.Substring(i, 1)));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        static private void InserePalavraHorizontal(string p)
        {
            try
            {
                int coluna = -1;
                int linha = -1;

                Thread.Sleep(Randomico);
                coluna = Randomico;
                while (coluna > totalDeColunas - p.Length)
                    coluna = coluna - (totalDeColunas - p.Length);

                while (VerificaLinhaOcupada(linha, p) || linha == -1)
                {
                    Thread.Sleep(Randomico);
                    linha = Randomico;
                    while (linha > totalDeLinhas - 1)
                        linha = linha - (totalDeLinhas - 1);
                }

                for (int i = 0; i < p.Length; i++)
                {
                    grid[linha, coluna + i] = Convert.ToChar(p.Substring(i, 1));
                    gridUsado[linha, coluna + i] = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static private void InserePalavraVertical(string p)
        {
            try
            {


                int coluna = -1;
                int linha = -1;
                bool escreveu = false;

                while (!escreveu)
                {
                    escreveu = true;

                    Thread.Sleep(Randomico);
                    linha = Randomico;
                    while (linha > totalDeLinhas - p.Length)
                        linha = linha - (totalDeLinhas - p.Length);

                    while (VerificaColunaOcupada(coluna, p) || coluna == -1)
                    {
                        Thread.Sleep(Randomico);
                        coluna = Randomico;
                        while (coluna > totalDeColunas - 1)
                            coluna = coluna - (totalDeColunas - 1);
                    }

                    for (int i = 0; i < p.Length; i++)
                    {
                        if (gridUsado[linha + i, coluna])
                            if (grid[linha + i, coluna] != Convert.ToChar(p.Substring(i, 1)))
                                escreveu = false;

                        grid[linha + i, coluna] = Convert.ToChar(p.Substring(i, 1));
                    }
                }

                for (int i = 0; i < p.Length; i++)
                    gridUsado[linha + i, coluna] = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static private void PopulaLetras()
        {
            try
            {
                letras.Add('a');
                letras.Add('b');
                letras.Add('c');
                letras.Add('d');
                letras.Add('e');
                letras.Add('f');
                letras.Add('g');
                letras.Add('h');
                letras.Add('i');
                letras.Add('j');
                letras.Add('k');
                letras.Add('l');
                letras.Add('m');
                letras.Add('n');
                letras.Add('o');
                letras.Add('p');
                letras.Add('q');
                letras.Add('r');
                letras.Add('s');
                letras.Add('t');
                letras.Add('u');
                letras.Add('v');
                letras.Add('w');
                letras.Add('x');
                letras.Add('y');
                letras.Add('z');
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static private void PopulaGrid()
        {
            try
            {
                int posicao = 1;

                for (int i = 0; i < totalDeLinhas; i++)
                {
                    for (int j = 0; j < totalDeColunas; j++)
                    {
                        posicao = posicao * Randomico;
                        posicao = posicao + i + j;

                        while (posicao > letras.Count - 1)
                            posicao = posicao - letras.Count;

                        if (!gridUsado[i, j])
                            grid[i, j] = letras[posicao];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static private bool VerificaLinhaOcupada(int linha, string palavra)
        {
            try
            {
                for (int i = 0; i < totalDeLinhas; i++)
                    if (linha == i)
                        for (int j = 0; j < totalDeColunas; j++)
                            if (gridUsado[i, j] == true)
                                return true;

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static private bool VerificaColunaOcupada(int coluna, string palavra)
        {
            try
            {
                for (int i = 0; i < totalDeLinhas; i++)
                    for (int j = 0; j < totalDeColunas; j++)
                        if (coluna == j)
                            if (gridUsado[i, j] == true)
                                return true;

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static private void ExibeGridLetras()
        {
            try
            {
                string linhaPopulada = string.Empty;

                for (int i = 0; i < totalDeLinhas; i++)
                {
                    linhaPopulada = string.Empty;

                    for (int j = 0; j < totalDeColunas; j++)
                        linhaPopulada = linhaPopulada + " " + grid[i, j];

                    Console.WriteLine(linhaPopulada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static private void ExibeGabarito()
        {
            try
            {
                string linhaPopulada = string.Empty;

                for (int i = 0; i < totalDeLinhas; i++)
                {
                    linhaPopulada = string.Empty;

                    for (int j = 0; j < totalDeColunas; j++)
                        if (gridUsado[i, j])
                            linhaPopulada = linhaPopulada + " 1";
                        else
                            linhaPopulada = linhaPopulada + " 0";

                    Console.WriteLine(linhaPopulada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
