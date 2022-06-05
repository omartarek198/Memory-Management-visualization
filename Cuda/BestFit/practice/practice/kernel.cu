#include<stdio.h>
#include<process.h>
#include "cuda_runtime.h"
#include "device_launch_parameters.h"
#include<conio.h>
__global__ void Add(int* a, int* p, int npart, int* indT, int* index, int* temp, int w)
{

    temp[0] = 9999;
    int j;
    j = threadIdx.x;
    if (a[j] >= p[w])
    {
        if (a[j] - p[w] < temp[0])
        {
            temp[0] = a[j] - p[w];
            index[0] = j;
        }
    }
    if (j == npart-1)
    {
        a[index[0]] -= p[w];
        p[w] = -1;
        printf("%d", a[index[0]]);
    }
}
/*__global__ void Add2(int* a, int* p, int npart, int* indT, int* index, int* temp, int w)
{

        int j;
        j = threadIdx.x;
        if (a[index[0]] == a[w])
        {
            index[0] = w;
            break;
        }
        a[index[0]] -= p[w];
        p[w] = -1;
}*/
/*
    
    
*/

int main()
{
    bool flag = false;
    int* a, * p, i, j, npro, npart, * temp, * index, * indT, * nn;
    printf("Enter no of Partitions.\n");
    

    scanf("%d", &npart);
    cudaMallocManaged(&a, npart * sizeof(int));
    for (i = 0;i < npart;i++)
    {
        printf("Enter the %dst Partition size:", i+1);
        scanf("%d", &a[i]);
    }
    printf("Enter no of Process.\n");
    scanf("%d", &npro);
    cudaMallocManaged(&p, npro * sizeof(int));
    for (i = 0;i < npro;i++)
    {
        printf("Enter the size of %dst Processes:", i+1);
        scanf("%d", &p[i]);
    }
    cudaMallocManaged(&temp, 1 * sizeof(int));
    cudaMallocManaged(&indT, 1 * sizeof(int));
    cudaMallocManaged(&index, 1 * sizeof(int));
    for (int w = 0;w < npro;w++)
    {
        Add << <1, npart >> > (a, p, npart, indT, index, temp, w);
        cudaDeviceSynchronize();

        printf("Process allocated to");
        printf("%d\n", index[0]);
        /*Add2 << <1, npart >> > (a, p, npart, indT, index, temp, w);
        cudaDeviceSynchronize();*/

    }
    for (i = 0;i < npro;i++)
    {
        if (p[i] != -1)
        {
            printf("Process %d must wait\n", i + 1);
        }
    }
    return 0;
    ///////////////////////////npart/npro/i/j/a[]/p[]/indT/index/temp/////////
}
