import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Olgun on 5/3/2018.
 */
public class main {

    public static int iteration = 0;

    public static void main(String[] args){

        System.out.println("---------------Welcome to prime number checker---------------");
        Scanner getNumber = new Scanner(System.in);

        System.out.println("1- Normal Method (Primality Test)");
        System.out.println("2- Second Method (Primality Test)");
        System.out.println();
        System.out.print("Your choice is: ");
        int choice = Integer.parseInt(getNumber.next());

        if(choice == 1) {
            System.out.print("Please enter a number: ");
            int number = Integer.parseInt(getNumber.next());
            if(isItPrime(number)){
                System.out.println(number + " is prime number\n" + iteration + " iteration is needed");
                factors(number);
            }else{
                printFactors(number);
            }
        }else if(choice == 2){
            System.out.print("Please enter a number: ");
            int number = Integer.parseInt(getNumber.next());
            if (isPrime(number)) {
                System.out.println(number + " is prime number");
            } else {
                printFactors(number);
            }
        }else{
            System.out.println("Wrong choice it must be (1-2)");
        }
    }

    static void printFactors(int number){

        System.out.println(number + " is not prime number");
        System.out.println(iteration + " iteration is needed");
        System.out.println("......Factors are ......");
        factors(number);
    }

    static void factors(int number){
        for(int i=1; i<=number; i++){
            if(number%i == 0){
                System.out.print(i + " ");
            }
        }
    }

    static boolean isItPrime(int n){

        //that means number is not prime because prime number must be greather than 1
        if(n <= 1){
            return false;
        }

        //To go until number-1 ex: 23 we will check until 22
        for(int i=2; i<n; i++){
            iteration += 1;
            //Check if the number is divisible by any number by 2 and less than number itself
            if (n % i == 0) {
                return false;
            }
        }

        return true;
    }


    static boolean isPrime(int n){

        int i = 2;
        int x = n;
        double b = (double)Math.sqrt(n);

        //To find the number square Root
        while(x > 1 && i <= b){

            while(x % i == 0){
                System.out.println(x + " is dividible by " + i);
                x = x/i;
                b = Math.sqrt(x);
            }
            i = i + 1;
            iteration += 1;
        }

        if(x == n){
            return true;
        }

        return false;
    }

}
