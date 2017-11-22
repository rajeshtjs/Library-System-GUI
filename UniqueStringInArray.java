/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package uniquestringinarray;
import java.util.*;
/**
 *
 * @author Rajesh Sampath
 */
public class UniqueStringInArray {

    /**
     * @param args the command line arguments
     */
    
    public static void main(String[] args) {
        String[] strArray = new String[] {"apple","cat", "apple", "ball", "apple"};
        String temp = findUinqueStrin(strArray);
        System.out.println(temp);
    }
    
    public static String findUinqueStrin(String [] array)
    {
        HashMap<Integer, String> hmap = new HashMap<Integer, String>();
        String str = "";
        
        for (int i =0; i< array.length; i++)
        {
            if (hmap.containsValue(array[i]))
            {
                str = array[i];
            }
            else
            {
                hmap.put(i, array[i]);
            }
        }
        
        return str;
    }
}
