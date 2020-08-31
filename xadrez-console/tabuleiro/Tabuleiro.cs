namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas; 

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna) 
        {
            return pecas[linha, coluna];
        }

        public Peca peca(Posicao pos) //<--sobrecarga do método Peca
        {
            return pecas[pos.linha, pos.coluna]; //<--Melhoria: vai retornar as peças nas posições
        }

        public bool existePeca(Posicao pos) 
        {
            validarPosicao(pos); //<---vai verifiar se a posição é válida, se não for válida a exceção será lançada
            return peca(pos) != null; //<--basicamente para verificar se existe peça é só verificar se é diferente de nulo, mas antes é importante verificar se a aquela posição é valida, por isso antes será executado acima que verifica se a posição é valida
        }
        
        public void colocarPeca(Peca p, Posicao pos)//<--Melhorado porque só "podemos colocar pecas onde não há peça"
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos; 
        }

        public bool posicaoValida(Posicao pos)
        {
            if (pos. linha < 0 || pos.linha > linhas || pos.coluna < 0 || pos.coluna > colunas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao pos)
        {
            if ( !posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
