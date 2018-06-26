import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Olgun on 5/3/2018.
 */
public class main {

    public static void main(String[] args){

        System.out.println("---------------Welcome to prime number checker---------------");
        Scanner getNumber = new Scanner(System.in);
        System.out.print("Please enter a number: ");
        int number = Integer.parseInt(getNumber.next());
        List<primeNumbers> primeNumbers_list = new ArrayList<primeNumbers>();

        for(int i=0; i<=number; i++){
            primeNumbers_list.add(new primeNumbers(i));
        }

        //if int num = 2; num * num <= num; num++ is more efficient because it will not check others if (num *num) is
        //greather than number that means others aldready checked

        //if num <= number it will check all of the numbers in the list from 2 to number
        for(int num = 2; num <= number; num++){

            if(primeNumbers_list.get(num).getPrime()){

                //System.out.println("Number itself: " + num); //2
                /*System.out.println("Number * Number: " + num * num); //4
                System.out.println("Number in the list: " + primeNumbers_list.get(num).getNumber()); // 4*/

                for(int i = num *2; i<= number; i = i + num){
                    /*System.out.println("i is: " + i);
                    System.out.println("value in the index " + i + " is: "  + primeNumbers_list.get(i).getNumber());*/
                    primeNumbers_list.get(i).setPrime(false);
                }
            }
        }

        boolean found = false;
        for(int i=2; i<=number; i++){

            if(primeNumbers_list.get(i).getPrime()){
                if(found){
                    System.out.print(",");
                }

                System.out.print(i);
                found = true;
            }
        }
    }

    public static class primeNumbers {

        long number;
        boolean prime;

        public primeNumbers(long number){
            this.number = number;
            this.prime = true;
        }

        public long getNumber() {
            return number;
        }

        public boolean getPrime(){
            return prime;
        }

        public void setNumber(long number) {
            this.number = number;
        }

        public void setPrime(boolean prime) {
            this.prime = prime;
        }
    }

}

