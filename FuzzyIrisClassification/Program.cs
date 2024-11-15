using System;

public class FuzzyIrisClassification
{
    // Definindo a tolerância para valores muito pequenos
    private const double TOLERANCIA = 0.0001;

    // Funções de pertinência triangulares para os conjuntos fuzzy
    // Definição para o comprimento da sépala (CS)
    public static double PertinenciaCS(double x)
    {
        if (x <= 4) return 0;
        if (x <= 6) return (x - 4) / 2;  // Triângulo: [4, 6, 8]
        if (x <= 8) return (8 - x) / 2;
        return 0;
    }

    // Definição para a largura da sépala (LS)
    public static double PertinenciaLS(double x)
    {
        if (x <= 2) return 0;
        if (x <= 3.5) return (x - 2) / 1.5;  // Triângulo: [2, 3.5, 5]
        if (x <= 5) return (5 - x) / 1.5;
        return 0;
    }

    // Definição para o comprimento da pétala (CP)
    public static double PertinenciaCP(double x)
    {
        if (x <= 1) return 0;
        if (x <= 4) return (x - 1) / 3;  // Triângulo: [1, 4, 7]
        if (x <= 7) return (7 - x) / 3;
        return 0;
    }

    // Definição para a largura da pétala (LP)
    public static double PertinenciaLP(double x)
    {
        if (x <= 0) return 0;
        if (x <= 1.5) return (x - 0) / 1.5;  // Triângulo: [0, 1.5, 3]
        if (x <= 3) return (3 - x) / 1.5;
        return 0;
    }

    // Função para verificar se a pertinência é muito pequena (próxima de zero)
    public static double TratarPertinencia(double pertinencia)
    {
        if (pertinencia < TOLERANCIA) return 0;
        return pertinencia;
    }

    // Função para determinar a classe com base nas regras
    public static string Classificar(double cs, double ls, double cp, double lp)
    {
        // Fuzzificando as entradas
        double pertinenciaCS = TratarPertinencia(PertinenciaCS(cs));
        double pertinenciaLS = TratarPertinencia(PertinenciaLS(ls));
        double pertinenciaCP = TratarPertinencia(PertinenciaCP(cp));
        double pertinenciaLP = TratarPertinencia(PertinenciaLP(lp));

        // Exibindo as pertinências formatadas
        Console.WriteLine($"Pertinência CS: {pertinenciaCS:F2}");
        Console.WriteLine($"Pertinência LS: {pertinenciaLS:F2}");
        Console.WriteLine($"Pertinência CP: {pertinenciaCP:F2}");
        Console.WriteLine($"Pertinência LP: {pertinenciaLP:F2}");

        // Verificando as regras para determinar a classe
        if (pertinenciaCS > 0.5 && pertinenciaLS > 0.5 && pertinenciaCP > 0.5 && pertinenciaLP > 0.5)
        {
            return "íris-versicolor";  // Regra 1
        }
        if (pertinenciaCS > 0 && pertinenciaLS > 0 && pertinenciaCP > 0 && pertinenciaLP > 0)
        {
            return "íris-setosa";  // Regra 2
        }
        if (pertinenciaCS > 0.5 && pertinenciaLS > 0.5 && pertinenciaCP > 0.5 && pertinenciaLP > 0.5)
        {
            return "íris-virginica";  // Regra 3
        }

        return "Classe desconhecida";  // Se não coincidir com nenhuma regra
    }

    public static void Main(string[] args)
    {
        // Entradas fornecidas
        double[] entrada1 = { 5.8, 4.1, 3.5, 1.1 };
        double[] entrada2 = { 7.8, 4.0, 6.7, 2.0 };

        // Classificando as entradas
        string classeEntrada1 = Classificar(entrada1[0], entrada1[1], entrada1[2], entrada1[3]);
        string classeEntrada2 = Classificar(entrada2[0], entrada2[1], entrada2[2], entrada2[3]);

        // Exibindo os resultados
        Console.WriteLine($"Classe para Entrada 1: {classeEntrada1}");
        Console.WriteLine($"Classe para Entrada 2: {classeEntrada2}");
    }
}
