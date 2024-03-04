using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Foguete.Search;

public class BinarySearch
{
    public static int Search<T>(List<T> collection, T value, int begin = 0, int end = -1)
    {
        end = end == -1 ? collection.Count : end;
        int mid;

        var comparer = Comparer<T>.Default;

        do
        {
            mid = (begin + end) / 2;
            
            if (comparer.Compare(collection[mid], value) == 0)
                return mid;
    
            if (comparer.Compare(collection[mid], value) < 0)
                begin = mid +1;
            else
                end = mid;
        } while (end > begin);

        return -1;
    }
}
