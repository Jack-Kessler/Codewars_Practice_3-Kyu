//Battleship Field Validator (3-Kyu) (Completed 2/15/2023)
//1 battleship (size of 4 cells), 2 cruisers (size 3), 3 destroyers (size 2) and 4 submarines (size 1)


int[,] field = new int[10, 10]
                     {{1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                      {1, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {1, 0, 0, 0, 1, 1, 1, 0, 1, 0},
                      {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 1, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 1, 1, 0, 0, 0, 0, 0, 0}};

//{
//    { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
//                      { 1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
//                      { 1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
//                      { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
//                      { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
//                      { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
//                      { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
//                      { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
//                      { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
//                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
//};

int totalNumOfOnes = 4 + (3 * 2) + (2 * 3) + (1 * 4);
int battleShipCount = 0;
int cruiserCount = 0;
int destroyerCount = 0;
int submarineCount = 0;

int typeOfShip = 1;

int i = 0;
int j = 0;
int oneCounter = 0;

bool result = true;
bool done = false;

List <int> yCoords = new List<int>(); //Stores coordinates of all 1s
List<int> xCoords = new List<int>(); //Stores coordinates of all 1s

List<int> temp = new List<int>(); //Stores index # to delete in yCoords and xCoords

for (i =0; i < field.GetLength(0); i++) //Row # (i.e. y axis)
{
    for (j = 0; j < field.GetLength(1); j++) //Column # (i.e. x axis)
    {
        if (field[i,j] == 1)
        {
            if ( i == 0 && j == 0)
            {
                if (field[i + 1, j + 1] == 1)
                {
                    done = true;
                    break;
                }
            }
            else if (i == 0 && j == 9)
            {
                if (field[i + 1, j - 1] == 1)
                {
                    done = true;
                    break;
                }
            }
            else if (i == 9 && j == 0)
            {
                if (field[i - 1, j + 1] == 1)
                {
                    done = true;
                    break;
                }
            }
            else if (i == 9 && j == 9)
            {
                if (field[i - 1, j - 1] == 1)
                {
                    done = true;
                    break;
                }
            }
            else if (i == 0)
            {
                if (field[i + 1, j - 1] == 1 || field[i + 1, j + 1] == 1)
                {
                    done = true;
                    break;
                }
            }
            else if (j == 0)
            {
                if (field[i - 1, j + 1] == 1 || field[i + 1, j + 1] == 1)
                {
                    done = true;
                    break;
                }
            }
            else if (i == 9)
            {
                if (field[i - 1, j + 1] == 1 || field[i - 1, j - 1] == 1)
                {
                    done = true;
                    break;
                }
            }
            else if (j == 9)
            {
                if (field[i - 1, j - 1] == 1 || field[i + 1, j - 1] == 1)
                {
                    done = true;
                    break;
                }
            }
            else
            {
                if (field[i - 1, j - 1] == 1 || field[i - 1, j + 1] == 1 || field[i + 1, j - 1] == 1 || field[i + 1, j + 1] == 1)
                {
                    done = true;
                    break;
                }
            }
            oneCounter++;
            if (oneCounter > totalNumOfOnes)
            {
                break;
            }
            else
            {
                yCoords.Add(i);
                xCoords.Add(j);
            }
        }
    }
    if (done == true)
    {
        break;
    }
}

if (oneCounter != totalNumOfOnes || done == true)
{
    result = false; ;
}
else
{
    for (i = 0; i < yCoords.Count; i++) //Check horizontal ships first
    {
        if (i + 4 < yCoords.Count)
        {
            if (yCoords[i + 1] == yCoords[i] && yCoords[i + 2] == yCoords[i] && yCoords[i + 3] == yCoords[i] && yCoords[i + 4] == yCoords[i])
            {
                if (xCoords[i + 1] == xCoords[i] + 1 && xCoords[i + 2] == xCoords[i] + 2 && xCoords[i + 3] == xCoords[i] + 3 && xCoords[i + 4] == xCoords[i] + 4)
                {
                    result = false;
                    break; //5 in a row. Return False.
                }
            }
        }
        if (i + 3 < yCoords.Count)
        {
            if (yCoords[i + 1] == yCoords[i] && yCoords[i + 2] == yCoords[i] && yCoords[i + 3] == yCoords[i])
            {
                if (xCoords[i + 1] == xCoords[i] + 1 && xCoords[i + 2] == xCoords[i] + 2 && xCoords[i + 3] == xCoords[i] + 3)
                {
                    battleShipCount++;
                    yCoords.RemoveRange(i, 4);
                    xCoords.RemoveRange(i, 4);
                    i--;
                }
            }
        }
        if (i + 2 < yCoords.Count)
        {
            if (yCoords[i + 1] == yCoords[i] && yCoords[i + 2] == yCoords[i])
            {
                if (xCoords[i + 1] == xCoords[i] + 1 && xCoords[i + 2] == xCoords[i] + 2)
                {
                    cruiserCount++;
                    yCoords.RemoveRange(i, 3);
                    xCoords.RemoveRange(i, 3);
                    i--;
                }

            }
        }
        if (i + 1 < yCoords.Count)
        {
            if (yCoords[i + 1] == yCoords[i])
            {
                if (xCoords[i + 1] == xCoords[i] + 1)
                {
                    destroyerCount++;
                    yCoords.RemoveRange(i, 2);
                    xCoords.RemoveRange(i, 2);
                    i--;
                }
            }
        }
    }
    int counter1 = 1;
    int counter2 = 1;
    if (result != false)  //To here is correct
    {
        for (i = 0; i + counter1 < xCoords.Count; i++) //Check vertical ships next
        {
            int a = yCoords[i];
            int b = xCoords[i];
            temp.Add(i);

            while (i + counter1 < xCoords.Count)
            {
                if (xCoords[i + counter1] == b)
                {
                    if (yCoords[i + counter1] == a + counter2)
                    {
                        typeOfShip++;                       //typeofship defaults at 1
                        temp.Add(i + counter1);
                        counter2++;
                    }
                }
                counter1++;
            }
            if (typeOfShip > 1)
            {
                if (typeOfShip > 4)
                {
                    result = false;
                    break; //5 in a row. Return False.
                }
                else if (typeOfShip == 4)
                {
                    battleShipCount++;
                }
                else if (typeOfShip == 3)
                {
                    cruiserCount++;
                }
                else if (typeOfShip == 2)
                {
                    destroyerCount++;
                }
                for (j = temp.Count - 1; j >= 0; j--)
                {
                    yCoords.RemoveRange(temp[j], 1);
                    xCoords.RemoveRange(temp[j], 1);
                }
                i--; //Need to start back at previous i because at least 2 elements in yCoords and xCoords were deleted and everything shifted down.
            }
            temp.Clear();
            counter1 = 1;
            counter2 = 1;
            typeOfShip = 1;
        }
        if (result != false)
        {
            submarineCount = yCoords.Count;
            if (battleShipCount != 1 || cruiserCount != 2 || destroyerCount != 3 || submarineCount != 4)
            {
                result = false;
            }
        }
    }
    
}

Console.WriteLine(result);
//return result;

//for (int z = 0; z < yCoords.Count; z++)
//{
//    Console.WriteLine(yCoords[z]);
//    Console.WriteLine(xCoords[z]);
//}