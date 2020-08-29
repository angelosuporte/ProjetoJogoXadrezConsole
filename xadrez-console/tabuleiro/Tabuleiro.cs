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

        public Peca peca(int linha, int coluna) //Método para acesso da peca individual à matriz, visto que o acesso externo à matriz foi bloquedo
        {
            return pecas[linha, coluna];
        }
        //Esta classe deve ter um método para oferecer operações de colocar uma peca no tabuleiro
        public void colocarPeca(Peca p, Posicao pos)
        {
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos; //<--onde a peça está(posição da peça) em relação em relação ao tabuleiro
        }
    }
}
