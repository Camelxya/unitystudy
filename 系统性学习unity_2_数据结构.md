## 三\.C#数据结构专场

#### Class 1 数组Array

###### 1\.1\.数组的基本概念

	数组是存储 相同数据类型 元素的 固定长度 集合，通过索引（从0开始）访问元素

	特点{
		固定大小：声明后长度不可变
		内存连续：元素在堆内存中连续存储，访问效率高
		强类型：所有元素类型必须一致，在声明的时候就已经确定了数据类型了
	}

###### 1\.2\.数组的声明和初始化

	声明数组：
	
		int[] number;
		
		string[] names;

		当声明一个public数组，在unity面板里面可以改变的是数组的长度和元素值，按下展开箭头就可以看到

	数组初始化

		法一：在声明时用new来隐式赋值确定长度	int[] arr1 = new int[5]; 

		法二：在声明的时候显式赋值	int[] arr2 = new int[]{1,2,3,4};
						或者简写	int[] arr3 = {1,2,3,4};

		法三：先声明后初始化，那这个初始化运算就要放在方法里进行了
				如：	double[] prices;
						prices = new double[]{9.9, 19.9, 29.9};

		默认值规则：值类型：int为0，bool为false等
					引用类型：null

###### 1\.3\.数组元素的修改

	以 int[] scores = {85,90,78,92}; 为案例基础

	int score1 = scores[0] //85	这是读取数组内元素，元素标记也是从0开始，同字符串

	scores[1] = 95 //{85,95,78,92}	这是修改数组内的某一个元素

	遍历数组的两种方式：

		for等循环语句
		for(int i = 0; i < scores.Length; i++){		//scores.Length是实例方法，返还值为整型，长度
			//在循环体中用scores[i]就可以顺序访问每一个元素了
		}

		foreach(int score in scores){
			//在循环体中用score就可以顺序访问每一个元素了
		}

###### 1\.4\.多维数组的拓展

	以二维数组为例：

		int[,] arr2D = new int[3,2]{
		{1,2},
		{3,4},
		{5,6}
		}
		声明+简化初始化，int[x,y]，x指行，y指列，这样说太抽象，可以理解成第x个一维数组中的第y个元素

		其实可以按新增维度放在前面来记，三维数组int[x,y,z]，第x个二维数组中的，第y个一维数组中的，第z个元素。	可以拓展到n维

		数组维度其实也有一个排序，也是从左往右，从0开始递增

###### 1\.5\.数组的常用方法和属性

	实例方法：

		Length 返还实例的总元素个数

		GetLength (int dimension) 返还指定维度长度，int dimension也就是数组维度的排序，
			
			对于int[x,y,z] points，points.GetLength(0) 返还 x ，points.GetLength(1) 返还 y ，points.GetLength(2) 返还 z

	静态方法（属于System）：

		Array.Sort(YourArray)	对YourArray进行升序排列

		Array.Reverse(YourArray)	对YourArray的数组元素顺序进行反转

		Array.IndexOf(YourArray,value)	查找元素首次出现的索引（未找到返还-1）

#### Class 2 列表List

###### 2\.1\.列表的基本概念

	List<T>是一个泛型的动态数组，默认初始容量为0，支持自动扩容，其中的 T 指代数据类型

###### 2\.2\.列表的声明和初始化

	声明列表：

		List<int> numbers; 创建一个名为number的List int类型的动态数组

	初始化列表：

		法1：

		空初始化 List<int> numbers = new List<int>();

		调用api接口增加元素 numbers.Add

		法2：

		List<int> numbers = new List<int>{1,2,3}; 初始化预先输入内容
	
###### 2\.3\.列表的常见操作

	元素增删

		numbers.Add(10);					//在末尾添加元素
		numbers.AddRange(new[]{20,30});		//在尾部批量添加集合元素，只要传入的对象可以被视为 IEnumerable<T>（可以被等同为可被foreach的对象，foreach以该接口为基础），那就都可以被放在AddRange的括号内作为拼接成分，类型不同则会隐式转换
		numbers.Insert(0,5);				//按索引插入元素，在索引0处插入元素

		numbers.Remove(10);					//删除首个匹配区
		numbers.RemoveAt(1);				//按索引删除元素，删除索引0的元素
		numbers.RemoveAll(n => n > 20);		//n=>是指示表达式，n>20是条件，也就是删除所有>20的元素
		numbers.Clear();					//全部删完

	查询遍历

		bool exists = numbers.Contains(10);		//检查List numbers里是否含有元素10，返回bool值
		int index = numbers.IndexOf(20);		//返还首个匹配项的索引
		List<int> elements = numbers.FindAll((n => n > 20);		//筛选出大于50的元素，返回值为按顺序容纳这些元素的列表

		foreach 和 for

	排序

		numbers.Sort();		//默认升序排序
		numbers.Sort((a,b)=> b.CompareTo(a));	//自定义排序，此处为降序
		numbers.Reverse();	//反转元素排序
		
	类型转换

		numbers.ConvertAll(n=> n.ToString());	//将容器内的数据转化成指定的数据类型，并用一个新List承接？（将列表中的元素转化成字符串）

#### Class 3 栈（又称堆栈）Stack

###### 3\.1\.栈的基本概念

	后进先出的线性数据结构，最后入栈的元素最先被移除

	想象一个向上开口的箱子，先规定每层只能放一个物品，为了充分利用箱子，物品一定是先从底部存起，并且由于只有一个出口，所以后放进去的先拿出来（后进先出）

	箱子内最低为栈底，箱子内最高的数据为栈顶

###### 3\.2\.栈的声明和初始化

	声明
		
		Stack<string> stack;	//string的位置填写数据类型

	初始化

		Stack<string> stack = new Stack<string>();	//空初始化
		stack.Push("Apple");
		stack.Push("Banana");

###### 3\.3\.栈的常用操作

	Push(T item)：	将元素压入栈顶
	Pop();			移除栈顶元素，并返回移除的元素（需确保栈非空）
	Peek();			查看栈顶元素但不移除
	Count;			获取当前栈内元素数量，这个是实时变化的，所以在进行Pop操作进行输出时，不能直接用Count作for的条件行
		问题为在i自增的时候，上界Count也在自减，所以实际上的执行次数只是预期的一半，下面是错误案例
		using System.Collections;
		using System.Collections.Generic;
		using UnityEngine;

		public class StackTest: MonoBehaviour
		{
			int[] nums = { 1, 2, 3, 4, 5, 6 };
			Stack<int> ints = new Stack<int>();
			// Start is called before the first frame update
			void Start()
			{
				foreach(int number in nums)
				{
					ints.Push(number);
				}

				for (int i = 0; i < ints.Count; i++)
				{
					Debug.Log(ints.Pop());
				}
			}

			// Update is called once per frame
			void Update()
			{
        
			}
		}
	Clear()		清除栈
	ToArray()	将一个栈转化为数组结构，类型上为隐式转换，可用于char型栈转化为按其顺序排列的字符串
		设有一个非空的Stack<char> M
		string s = new string(M.ToArray);

	foreach 能遍历

#### Class 4 队列 Queue

###### 4\.1\.队列的基本概念

	先进先出
	
	相比栈是一个单独开口的箱子，箱子内每层只能放一个数据，队列的变化是有两个交互口，数据在里面单向流通,就像一个队列，数据现在这里排队，然后按次序离开

	元素进入队列，叫作入队，离开队列叫作出队，队头是最先输出的那个，队尾是最近输入的那个

###### 4\.2\.队列的声明和初始化

	声明

		Queue<string> queue;

	队列的初始化

		Queue<string> queue = new Queue<string>();
		queue.Enqueue("Vip");

###### 4\.3\.队列的常用操作

	Enqueue(T)	在队尾加上元素
	Dequeue()	移除队头元素，并返回移除的元素
	Peek()		查看队头元素（不删除）
	Count		获取队列中的元素个数，注意点同Stack
	Clear()		清除队列

	foreach 能遍历

#### Class 5 字典Dictionart

###### 5\.1\.字典的基本概念

	Dictionary<TKey><TValue> 通过键Key访问值Value

	唯一键约束
	高效查找
	动态扩容
	强类型声明

###### 5\.2\.字典的声明和初始化

	声明

		Dictionary<string><int> ages = new Dictionary<string,int>();
		
	初始化字典

		Dictionary<string><int> ages = new Dictionary<string,int>();
		ages.Add("张三",3);

###### 5\.3\.字典的常用操作

	Add("张三"，3);		前是键，后是值
	dict["张三"] = 3;	通过键赋值

	TryGetValue(key, out value);通过键获取值

	Remove(Tkey key);			通过键删除值

	Count	返还字典长度

	ContainsKey(key)	返还key是否存在于该字典中的bool值

	foreach(KeyValuePair(string, int) item in ages)
	{
		//遍历主体，遍历时Key和Value都进行，只要注意这个变量类型，用var省事
	}

	foreach(string item in ages.Keys)
	{
		//遍历主体，只遍历Key，注意这个变量类型，和遍历对象
	}

	foreach(int item in ages.Values)
	{
		//遍历主体，只遍历Value，注意这个变量类型，和遍历对象
	}

	利用for遍历也行，因为字典其实也是有索引的，对应的类为，dict.ElementAt(i)，需要第i+1位的Key，那么可用dict.Element(i).Key