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

        public Peca peca(Posicao pos) 
        {
            return pecas[pos.linha, pos.coluna]; 
        }

        public bool existePeca(Posicao pos) 
        {
            validarPosicao(pos); 
            return peca(pos) != null;
        }
        
        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos; 
        }

        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null) //<-- se não tem nenhuma peça naquela posição, não será retirado o que não tem, vai retornar null
            {
                return null;
            }//--se passar desse if é porque tem uma peça ali
            Peca aux = peca(pos);//<-- a variável aux vai receber a peça
            aux.posicao = null; //<-- nesse passo ao atribuir naquela posição o valor null a peça é retirada
            pecas[pos.linha, pos.coluna] = null; //internamente vai atribuir null à matriz
            return aux;

        }

        public bool posicaoValida(Posicao pos)
        {
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
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
