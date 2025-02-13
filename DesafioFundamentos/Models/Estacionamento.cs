using System.Text.RegularExpressions;
namespace DesafioFundamentos.Models

{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // IMPLEMENTADO 
            /* 
            Decidi inserir uma validação para saber se o input corresponde a algum modelo de placa de acordo com as normas BR e/ou Mercosul.

            Também tomei a liberdade de inserir uma lógica que verifica se a placa já existe ou não na lista.
            */
            
            string placaDoVeiculo; 
            
            do{
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                placaDoVeiculo = Console.ReadLine().ToUpper();
                
                Regex placaBr = new Regex(@"^[a-zA-Z]{3}-[0-9]{4}$");
                Regex placaMercosul = new Regex(@"^[a-zA-Z0-9]{7}$");
                
                if (veiculos.Any(x => x.ToUpper() == placaDoVeiculo.ToUpper())){
                    Console.WriteLine("Veículo já cadastrado no sistema!");
                    break;
                }
                else if (placaBr.IsMatch(placaDoVeiculo) || placaMercosul.IsMatch(placaDoVeiculo))
                {
                    veiculos.Add(placaDoVeiculo);
                    Console.WriteLine("Placa registrada com sucesso!");
                    break;
                }
                else
                {
                    Console.WriteLine($"A placa {placaDoVeiculo} precisa corresponder ao modelo BR (ABC-1234)" +
                    "ou ao modelo Mercosul (1A2B3C4), por favor, repita.");
                }
            } while (true);

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // IMPLEMENTADO
            string placa = Console.ReadLine().ToUpper();;

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // IMPLEMENTADO
                int horas = 0;
                horas =  Convert.ToInt32(Console.ReadLine());

                decimal valorTotal = precoInicial + precoPorHora * horas;

                // IMPLEMENTADO
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // IMPLEMENTADO
                for (int i = 0; i < veiculos.Count; i++){
                    Console.WriteLine(veiculos[i]);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
