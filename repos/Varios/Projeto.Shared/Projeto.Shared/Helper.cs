using System;

namespace Projeto.Shared
{
    public static class Helper
    {
        public static bool VerificaIdadadeDeRisco(int idade)
        {
            if(idade>=18) return true;else return false;
        }
        public static bool VerificaNomeDeReisco(string nome)
        {
            if (nome == "corona") return false; else return true;
        }
    }
}
