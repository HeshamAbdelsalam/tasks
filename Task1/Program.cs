using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("-----------declarng the array to work on-----------  ");
                //Console.WriteLine("-3>-2={0}",-3>-2?true:false);
                Console.Write("enter array width=");
                int arrayWidth = int.Parse(Console.ReadLine());
                Console.Write("enter array height=");
                int arrayHeight = int.Parse(Console.ReadLine());
                Console.Write("enter array Depth=");
                int arrayDepth = int.Parse(Console.ReadLine());
                ArrayElement[,,] arr = new ArrayElement[arrayWidth, arrayHeight, arrayDepth];
                Console.WriteLine("------inserting items in the 3 dims array----------");
                for (int i = 0; i < arrayDepth; i++)
                {
                    Console.WriteLine("-------Depth= {0}--------", i);
                    for (int j = 0; j < arrayHeight; j++)
                    {
                        for (int k = 0; k < arrayWidth; k++)
                        {
                            Console.Write("enetr element [{0},{1},{2}]=", k, j, i);
                            arr[k, j, i] = new ArrayElement() { value = int.Parse(Console.ReadLine()), x = k, y = j, z = i };
                        }
                        Console.WriteLine("");
                    }

                }
                Console.WriteLine("------displying the 3 dims array----------");
                for (int i = 0; i < arrayDepth; i++)
                {
                    Console.WriteLine("-------Depth= {0}--------", i);
                    for (int j = 0; j < arrayHeight; j++)
                    {
                        for (int k = 0; k < arrayWidth; k++)
                        {
                            Console.Write(" " + arr[k, j, i].value);
                        }
                        Console.WriteLine("");
                    }

                }
                bool targetError = false;
                ArrayElement target = new ArrayElement();
                do
                {
                    Console.WriteLine(" -------------define the target:");
                    Console.Write("enetr x=");
                    int x = 0;
                    if (!(int.TryParse(Console.ReadLine(), out x)))
                    {
                        targetError = true;
                        Console.WriteLine("error try again");
                        break;
                    }
                    Console.Write("enetr y=");
                    int y = 0;
                    if (!(int.TryParse(Console.ReadLine(), out y)))
                    {
                        targetError = true;
                        Console.WriteLine("error try again");
                        break;
                    }
                    Console.Write("enetr z=");
                    int z = 0;
                    if (!(int.TryParse(Console.ReadLine(), out z)))
                    {
                        targetError = true;
                        Console.WriteLine("error try again");
                        break;
                    }
                    target.x = x;
                    target.y = y;
                    target.z = z;
                    target.value = arr[x, y, z].value;
                    Console.WriteLine("the target[{0},{1},{2}]={3}", x, y, z, target.value);
                } while (targetError);

                ArrayElement res = getClosestElement(arrayWidth, arrayHeight, arrayDepth, arr, target);
                Console.WriteLine("the nearst element is[{0},{1},{2}]={3}", res.x, res.y, res.z, res.value);

            Console.ReadLine();
        }//end of main()

        static ArrayElement resElement=null;
        //get the nearest element that is greater than the target
        public static ArrayElement getClosestElement(int arrayWidth,int arrayHeight,int arrayDepth,ArrayElement[,,] arr ,ArrayElement target)
        {
            bool getFisrtElemment = true;
            for (int i = 0; i < arrayDepth; i++)
            {
                for (int k = 0; k < arrayHeight; k++)
                {
                    for (int j = 0; j < arrayWidth; j++)
                    {
                            if ((arr[j, k, i].value > target.value))
                            {
                                if(getFisrtElemment)
                                {
                                    resElement = arr[j, k, i];
                                    getFisrtElemment = false;
                                    continue;
                                }
                           
                                ArrayElement resElement1 = compareClosest(arr[j, k, i], resElement, target);
                            }      
                    }
                }
            }
            return resElement;
        }//end of getClosestElement()
        //find the nearst element to the target
        public static ArrayElement compareClosest(ArrayElement element1, ArrayElement element2, ArrayElement target)
        {
            int targetPointSum = (target.x + target.y + target.z);
            int elm1pointSum= (element1.x + element1.y + element1.z);
            int elem2PointSum= (element2.x + element2.y + element2.z);
            int elm1 = 0;
            int elm2 = 0;
            if(targetPointSum>elm1pointSum)
            {
                elm1 = targetPointSum - elm1pointSum;
            }else
            {
                elm1 = elm1pointSum - targetPointSum;
            }
            if (targetPointSum > elem2PointSum)
            {
                elm2 = targetPointSum - elem2PointSum;
            }else
            {
                elm2 = elem2PointSum - targetPointSum;
            }

            if (element2.x == target.x && element2.value == target.value && element2.y == target.y &&  element2.z == target.z)
              {
                return element1;
              }
            else if (elm1 > elm2)
                {
                    return element2;
                }
                else
                {
                    return element1;
                }
           
        }//end of compareClosest()


    }//end of program
}//end of namespace
