#include <iostream>

#if defined(DEBUG)
#define TEST_VALUE = 123
#elif defined(RELEASE)
#define TEST_VALUE = 456
#endif


int main(int argc, char* argv[])
{
	std::cout << "Hello World!" << std::endl;
	return 0;
}