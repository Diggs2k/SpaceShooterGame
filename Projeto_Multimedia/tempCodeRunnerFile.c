#include <stdio.h>

int main() {

    int a = 10;
    int *ptr = a;

    printf("a = %d", a);
    printf("ptr = %d", *ptr);

    return 0
}

float average(unsigned char * array_ptr;int n){
    float sum = 0;

    for(int i = 0; i<n; i++){
        sum = sum + array_ptr[i];
    }

    return sum/n;
}

float average2(unsigned char * array_ptr;int *n){
    float sum = 0;

    for(int i = 0; i<n*; i++){
        sum = sum + array_ptr[i];
    }

    return sum/n*;
}

void average3(unsigned char * array_ptr;int n,float *result){
    float sum = 0;

    for(int i = 0; i<n; i++){
        sum = sum + array_ptr[i];
    }

    *result = sum/n;
}