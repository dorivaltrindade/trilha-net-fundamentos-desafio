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
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            // letras maiúsculas na identificação das placas
            string placa = Console.ReadLine().ToUpper();
            // placas sem espaço em branco entre os caracters
            placa = placa.Replace(" ", "");
            // caso a placa já esteja cadastrada, não adicionar
            if (!veiculos.Contains(placa)){
                veiculos.Add(placa);
                veiculos.Sort();
                Console.WriteLine($"🚗 Veículo Placa {placa} - ok 😉✔");
            } else {
                Console.WriteLine($"Placa  [ {placa} ]  já está cadastrada! 😕❌");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine($"Digite a quantidade de horas que o veículo [{placa}] permaneceu estacionado:");
               
                // *IMPLEMENTE AQUI*
                string horasInformadas = Console.ReadLine();
                int.TryParse(horasInformadas, out int horas);
                decimal valorTotal = precoPorHora*horas + precoInicial*((horas>0)?1:0);

                // TODO: Remover a placa digitada da lista de veículos
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal.ToString("F2")} 💰");
            }
            else
            {
                Console.WriteLine($"Desculpe, esse veículo [{placa}] não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine($"Veículo{((veiculos.Count>1)?"s":"")} estacionado{((veiculos.Count>1)?"s":"")} [{veiculos.Count}]:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                foreach (string item in veiculos){
                    Console.WriteLine($"🚗 {item}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.❌");
            }
        }
    }
}
