namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
        }

        public void incrementarQteMovimentos()
        {
            qteMovimentos++;
        }
        
        public bool existeMovimentosPossiveis() 
        {
            bool[,] mat = movimentosPossiveis();
            for(int i = 0; i < tab.linhas; i++)
            {
                for(int j = 0; j < tab.colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false; //<--se percorreu a matriz e verificou que não existe movimentos possíveis vai retornar falso
        }

        public bool podeMoverPara(Posicao pos) //Vamos descrever os passos para:
        {
            return movimentosPossiveis()[pos.linha, pos.coluna]; //<--- 1º Passo: O método movimentosPossiveis é especializado de acordo com cada Classe que especifica o tipo de peça, Ex.: torre, rei e etc.
        }

        public abstract bool[,] movimentosPossiveis(); 
        
    }
}
