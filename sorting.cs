using System;

public static class Sorting
//BubbleSort: Enkel men ineffektiv. Jämför och byter platser upprepade gånger.
//InsertionSort: Effektivare för små eller delvis sorterade arrayer. Sätter in element på rätt plats.
//MergeSort: Effektiv för stora arrayer. Dela och slå samman.
//QuickSort: Mycket effektiv med rätt pivotval. Delar arrayen runt en pivot.
{
    //BubbleSorting
    public static void BubbleSort(int[] array) 
    //Går genom arrayen flera gånger
    //Jamför varje par av intilliggande element och byte rplats på dem om de är i fel ordning
    //Största värdet "Bubblar" upp till slutet av arrayen i varje iteration
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++) // Yttre loop aom körs n-1 gånger
        {
            for (int j = 0; j < n - i - 1; j++) //Inre Loop som jamför och byter element
             {
                if (array[j] > array[j + 1]){
                    Swap(array, j, j + 1); //Byter plats på två elemnt om de är i fel ordning
                }
            }
        }
    }

//InsertionSorting
    public static void InsertionSort(int[] array)
    //Tar ett elemtn från osorterade delen av arrayen
    //Flyttar det till rätt position i den redan sorterade delen av arrayen
    {
        int n = array.Length;
        for (int i = 1; i < n; i++) //Iterar över arrayen från det andra elementet
        {
        int key = array[i];
        int j = i - 1;
            while (j >= 0 && array[j] > key) //Flyttar större element till höger för att skapa plats för det nya elementet
            {
                array[j + 1] = array[j]; 
                j--;
            }
            array[j + 1] = key; //Sätter in elementet på rätt plats.
        }
    }

//MergeSorting
    public static void MergeSort(int[] array)
    //Delar upp arrayen i mindre delar tills varje del består av ett element.
    //Slår ihop delarna i sorerad ordning
    {
        MergeHelper(array, 0, array.Length - 1);
    }

    private static void MergeHelper(int[] array, int left, int right) //Hjälpmetoder
    //Delar upp arrayen rekusivt
    {
        if (left < right)
        {
        int mid = (left + right) / 2; // beräknar mitten av arrayen
        MergeHelper(array, left, mid);
        MergeHelper(array, mid + 1, right);
        Merge(array, left, mid, right);
        }
        //Anropar sig själv för vänster och höger del
    }

    private static void Merge(int[] array, int left, int mid, int right)
    //Slår ihop två sorterade delarrayer
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;
        int[] L = new int[n1];
        int[] R = new int[n2];
        Array.Copy(array, left, L, 0, n1); //Kopierar data från orginalaaryen till tillfälliga arryer
        Array.Copy(array, mid + 1, R, 0, n2);

        int i = 0, j = 0, k = left;
        while (i < n1 && j < n2) //Slår samman elementen i sorterad ordning
        {
            if (L[i] <= R[j]){
                array[k++] = L[i++];
            }
            else{
                array[k++] = R[j++];
            }
        }
        //Resterade element kopierad tillbaka till orindalarryen
        while (i < n1){
            array[k++] = L[i++];
        }
        while (j < n2){
            array[k++] = R[j++];
        }
    }

//QuickSorting
    public static void QuickSort(int[] array) 
    //Väljer ett pivot-element
    //Omorganserar arrysen så att alla element minde än pivpt är till vänster och större till höger.
    //Anropar sig själv för vänster och höger del.
    {
        QuickHelper(array, 0, array.Length - 1);
    }

    private static void QuickHelper(int[] array, int low, int high) //Hanterar rekursionen
    //Delar arrayen runt en pivot
    {
        if (low < high)
        {
            int pi = Partition(array, low, high);
            QuickHelper(array, low, pi - 1);
            QuickHelper(array, pi + 1, high);
        }
    }

    private static int Partition(int[] array, int low, int high)
    //Väljer sista elmentet som pivot
    //Flyttar element mindre än pivot till vänster och större till höger
    {
        int pivot = array[high];
        int i = (low - 1);
        for (int j = low; j < high; j++)
        {
            if (array[j] <= pivot){
                i++;
                Swap(array, i, j);
            }
        }
        Swap(array, i + 1, high); //Byster pivot till rätt position
        
        return i + 1;
    }

    private static void Swap(int[] array, int i, int j)
    //Hjälpmetod för att byta plats på två element i arrayen
    //Temporär variabel används för tt undvika att förlora värden
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}
