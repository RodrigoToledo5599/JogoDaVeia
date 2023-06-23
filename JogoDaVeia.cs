using System;

namespace JogoDaVeia
{
    internal class JogoDaVeia
    {
        private bool fimDeJogo;
        private char[] posicoes;
        private char vez;
        private int quantidadePreenchida;

        public JogoDaVeia()
        {
            fimDeJogo = false;
            posicoes = new[]{'1','2','3','4','5','6','7','8','9'};
            vez = 'X';
            quantidadePreenchida = 0;

        }

        public void Iniciar()
        {
            while (!fimDeJogo)
            {
                RenderizarTabela();
                LerEscolhaDoUsuario();
                RenderizarTabela();
                VerificarFimDeJogo();
                MudarAVez();
            }
        }

        private void MudarAVez()
        {
            vez = vez == 'X' ? 'O' : 'X';
        }

        private void VerificarFimDeJogo()
        {
            if(quantidadePreenchida < 5)
            {
                return;
            }

            if(ExisteVitoriaDiagonal() || ExisteVitoriaHorizontal() || ExisteVitorioaVertical())
            {
                fimDeJogo = true;
                Console.WriteLine($"jogador {vez} venceu");
            }
            if(quantidadePreenchida is 9)
            {
                fimDeJogo = true;
                Console.WriteLine("Empate");
            }
        }

        private bool ExisteVitoriaHorizontal()
        {
            bool vitorialinha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool vitorialinha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool vitorialinha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];
            return vitorialinha1 || vitorialinha2 || vitorialinha3;
        }

        private bool ExisteVitorioaVertical()
        {
            bool vitoriaColuna1 = posicoes[0] == posicoes[3] && posicoes[3] == posicoes[6];
            bool vitoriaColuna2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool vitoriaColuna3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];
            return vitoriaColuna1 || vitoriaColuna2 || vitoriaColuna3;
        }

        private bool ExisteVitoriaDiagonal()
        {
            bool vitoriDiagonal1 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];
            bool vitoriDiagonal2 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];
            return vitoriDiagonal1 || vitoriDiagonal2;  
        }



        private void LerEscolhaDoUsuario()
        {
            Console.WriteLine($"É a vez de {vez}:");
            bool conversao = int.TryParse(s: Console.ReadLine(), out int posicaoEscolhida);
            while(!conversao || !ValidarEscolhaDeUsuario(posicaoEscolhida))
            {
                Console.WriteLine("Escolhe direito krl!!");
                conversao = int.TryParse(s: Console.ReadLine(), out posicaoEscolhida);

            }
            PreencherEscolha(posicaoEscolhida);
        }

        private void PreencherEscolha(int posicaoEscolhida)
        {
            ValidarEscolhaDeUsuario(posicaoEscolhida);
            int indice = posicaoEscolhida - 1;
            posicoes[indice] = vez;
            quantidadePreenchida++;
        }


        private bool ValidarEscolhaDeUsuario(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;
            if (posicoes[indice] == 'O' || posicaoEscolhida == 'X')
            {
                return false;
            }
            else if(posicoes[indice] == 'X' || posicaoEscolhida == 'O')
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void RenderizarTabela()
        {
            Console.Clear();
            Console.WriteLine(ObterTabela());
        }

        private string ObterTabela()
        {
            return $"  {posicoes[0]}  |  {posicoes[1]}  |  {posicoes[2]}  \n"+
                    "_________________\n"+
                   $"  {posicoes[3]}  |  {posicoes[4]}  |  {posicoes[5]}  \n"+
                    "_________________\n"+
                   $"  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  \n";
        }
    }
}
