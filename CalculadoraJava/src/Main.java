import java.util.Scanner;
public class Main {
	public static void main(String [] args) {
		
		Scanner scan =  new Scanner(System.in);
		
		Operacao soma = new Operacao(new Soma());
		Operacao subtracao = new Operacao(new Subtracao());
		Operacao multiplicacao = new Operacao(new Multiplicacao());
		Operacao divisao = new Operacao(new Divisao());
		Operacao potencia = new Operacao(new Potencia());
		Operacao raiz = new Operacao(new Raiz());
		Operacao raiz2 = new Operacao(new Raiz2());
		
		
		System.out.println("----------------------------------------------------CALCULADORA---------------------------------------------------------------");
		
		System.out.println("[1] Soma\n[2] Subtração\n[3] Multiplicação\n[4] Divisão\n[5] Potênciação\n[6] Raiz Quadrada");
		int c = scan.nextInt();
		

		System.out.println("Primeiro valor");
		double a = scan.nextDouble();
		System.out.println("Segundo Valor");
		double b = scan.nextDouble();
		
		switch(c) {
		case 1:
		System.out.println("Soma: "+soma.Conta(a, b));
		break;
		case 2:
			
		System.out.println("Subtração: "+subtracao.Conta(a, b));
		break;
		case 3: 
		System.out.println("Multiplicação: "+multiplicacao.Conta(a, b));
		break;
		case 4:
		System.out.println("Divisão: "+divisao.Conta(a, b));
		break;
		case 5:
		System.out.println("Potênciação: "+potencia.Conta(a, b));	
		break;
		case 6:
		System.out.println("Raiz Quadrada de A: "+raiz.Conta(a, b));	
		System.out.println("Raiz Quadrada de B: "+raiz2.Conta(a, b));	
		break;
		}
		

	}

}
