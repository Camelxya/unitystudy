## 一\.Unity和C#概览

#### 1\.Unity是什么

	一个跨平台的游戏引擎和开发工具，用于创建2D/3D游戏、VR、AR等交互式内容

	游戏：原神、崩坏、纪念碑谷、征途、王者荣耀

	具有图形渲染、物理模拟、动画系统、音效管理等一些核心底层功能

#### 2\.为什么是C#被推荐

	易用性和生产力：体现在高级、类型安全、语法清晰、易于学习

	托管环境与安全性：运行在.NET框架中，提供内存管理

	跨平台兼容性：Unity可以将C#代码编译为中间语言，多平台运行

	强大的生态：前人栽的树多

#### 3\.C#能做什么

	驱动游戏逻辑、访问Unity API、事件驱动编程、自定义组件



## 二\.C#语法专场

#### Class 1

###### 1\.1\.类class

	类的定义是以关键字class开始，后跟“类的名称”以及“类的主体”，最后将行为数据包含在一对花括号内

	class的前面可以追加访问修饰符（Access Specifier，常见有public、private、protected），不过是可选的，不加默认私有（private）

	如：
	public class Example
	{
		int value_1；
		int value_2;
		float value_3;
		…
	}
	创造了一个名叫Example的类，含有value

	类名后面可以用冒号继承类的性质，冒号意为“继承自”

	·*MonoBehavior*是Unity引擎提供的类，包含了很多生命周期的方法（
	AWake：实例被加载时调用，用于初始化或设定初始状态。在游戏对象启用之前调用
	OnEnable：当脚本或对象被激活时调用，用于处理对象激活时的逻辑
	Start：在所有Awake()方法调用完成后并且所用游戏对象已启用时调用，用于脚本初始化、游戏逻辑初始化。在第一次Upadate发生之前调用
	Update：每渲染帧调用一次，用于常规的游戏逻辑处理，如输入检测、对象移动
	Destroy：当游戏对象被销毁时调用，用于释放资源或执行清理操作
	等

	类只负责编译前与编译中的运行

	类中只能包含字段声明、初始化，属性、方法、构造函数，具体单独的赋值等运算放到类里会直接报错

	类不执行具体的运算，随机数生成是在编译后进行的，所以放到类里面，会导致程序不执行，也就是数值仍然是初始化时的数值

###### 1\.2\.方法Method（Method并非关键字，而是常用称呼）

	把一堆相关的语句组织到一起，共同完成一个任务（业务逻辑），称该结构为方法

	方法前有访问修饰符，默认private

	方法有返回值，返回值有类型（Return Type），void类型的可以不返回值，常见类型有void、dateType、object

	方法有方法名
	
	方法有参数列表，但是参数列表可以省略不写，但是其括号必须有

	模式范例：
	<Access Specifier><Return Type><Method Name>(Parameter List)
	{
		Method Body
	}

	<访问类型><返回类型><方法名>(参数列表)
	{
		方法主体
	}

###### 1\.3\.在unity日志上显示的函数 Debug.Log

	Debug.Log("");输出白色日志（普通）

	Debug.LogWarning("");输出黄色日志（警告）

	Debug.LogError("");输出红色日志（错误）

	Debug.LogFormat("{0}{1}{2}",变量1，变量2，变量3)；	//不会输出花括号，只会输出三个变量，黄和红也有自己的Format

	Debug.Log()中的字符串用＋连接，只要一边是字符串，另一边自动进行ToString()的隐式转换，这种转换是随着加法顺序进行的，每次加法计算之前会进行一次判定

		Debug.Log(1 + " " + 2);输出1 2	//第一步1被转换了

		Debug.Log(1 + ' ' + 2);输出3	//没有字符串，所以不进行隐式转换

		Debug.Log(" " + 1 + 2);输出12	//1先被隐性转换

###### 1\.4\.unityC#文件的特殊注意点

	文件名为 The_first_class_Hello_World.cs ，原初始代码如下：

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class The_first_class_Hello_World : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
        
		}

		// Update is called once per frame
		void Update()
		{
        
		}
	}

	注意到文件中存在一个类，类名为 The_first_class_Hello_World 这与文件名相同，这是必须要满足的，不能只改文件名而不改类名
	注意到该类继承了前文所述的MonoBehaviour

###### 1\.5\.编码新注意

	必须是英文状态，
	
	方法调用中：
	静态方法用“类名.”+“方法名”来调用，静态调用
	普通方法用“类对象.”+“方法名”来调用，对象调用
	有些方法有两套逻辑，一套静态调用，一套对象调用
		例：Equals,string.Equals()是静态调用，对象名.Equals()是对象调用

	在unity中创建的C#的文件，文件名必须全英文，文件内类名应与文件名相同

	注释方法
	//<内容>    单行注释
	/*<内容>*/  多行注释

#### Class 2

###### 2\.1\.变量

	变量是用于存储的单元整体，有代号（变量名），有储存的信息

	变量具有数据类型，不同的分类是为了更加灵活的存放数据

###### 2\.2\.数据类型分类的详细说明

	所有编程语言中都有栈（存放简单小型的数据）、堆（存放复杂大型数据）的概念，栈的操作速度比堆要快得多

	数据在大类上可以分为：值类型（数据直接放在栈里）、引用类型（数据存放在堆里，而栈里面存着一个引用，指向这个堆，我理解成指针）

	即大类分为：值类型、引用类型

	值类型{
		基本类型{
			整数类型{
				sbyte	有符号8位（所谓有符号，就是n+1负，n正，还有0），127（记上界）
				byte	无符号8位	255
				short	有符号16位	32767
				ushort	无符号16位	65536
				int		有符号32位	2147483647
				uint	无符号32位	4294967295
				long	有符号64位	9223372036854775807
				ulong	无符号64位	18446744073709551615	
			}
			浮点类型{
				float	有符号32位（7-8位有效数字）
				double	有符号64位（15-17有效数字）
				decimal	有符号128位（27-28位有效数字）
			}
			字符类型 char	16位Unicode字符	U+0000-U+FFFF
			布尔类型 bool	一个字节，表示真或假 true/false
		}
		自定义类型{
			结构体	struct
			枚举	enum
		}
	}
	引用类型{
		常见类型{
			字符串类型	string	表示文本字符串类型
			类		class		描述一类对象的共同特征
			接口	interface	跟“类”类似，就是不含数据和具体方法
			委托	delegate	一种类型安全的函数指针，用于封装和传递方法
			数组
			物体	object
		}
	}

	所有的声明操作实际上是在栈上开辟内存，对于引用类型来说，开辟的这个内存储存的是一个地址

	new string等的返还值其实也是一个地址，但它同时在堆中申请出了一块内存用于

	引用类型的赋值事实上是将地址赋给其它变量，不改变堆里的数据

###### 2\.3\.关于引用类型和值类型的一点补充

	装箱拆箱{
		装箱：将值类型转换为引用类型的过程，需要从堆里面申请一块内存去存放
		拆箱：将引用类型转换回原始值类型的过程
	}

	注意频繁装箱/拆箱（放到循环中）会显著增加CPU和内存压力，因为涉及到代码逻辑的操作

	例子：

		int num = 42;				//将值类型放到栈上
		object boxed = num;			//装箱：将num的值装进堆内存，产生额外的内存开销

		int unboxed = (int)boxed;	//拆箱：从箱里取出int的值，赋给unboxed，从堆内存中复制数据回栈，但需验证匹配类型

###### 2\.4\.变量的基本用法

	变量的初始化：变量必须先声明后使用，未初始化的变量可能导致编译错误

	变量的作用域：
	
		局部变量：在代码块（一个除类外的大括号内，可以是方法，可以是循环后，可以是条件后，等等等）内生命，仅在该块有效

		成员变量：在类中声明，作用域为整个类（需结合访问修饰符控制可见性）

		注意1：类的大括号不是用来划分区域的，只是用来封装的，和局部大括号是不同的

		注意2：在类里面的单独的大括号是构造代码块

		注意3：在局部（方法、代码块）内不能声明一个public变量，这会让文件直接挂掉，因为方法内的变量是局部变量，没有公开概念

		注意4：类Class下定义的变量，允许在该类下的方法中定义一个同名局部变量，而在方法中调用时默认使用局部变量值

	变量类型的转换规则：

		隐式转换：低精度类型自动提升为高精度类型（如int到double）(数值上的隐式转换看的是安全性，并不关注本次转换的值，只要范围是包含与被包含的关系，那就可以小转大)

		显示转换（强制转换）：

			高精度类型向低精度类型转换，需显示转换，如(int)3.14=3

			Convert类，支持跨类型转换，如 Convent.ToInt32("123")

			Parse/TryParse方法(每个数据类型都有一个对应的P和TP方法，被转化的对象只能是字符串)：

				Parse转换失败时抛出异常；int.Parse("abc")

				TryParse在转换的同时会返回bool值标识结果，可以这样使用 bool bSuccessed = int.TryParse("123",out int x)

		字符串与其它类型互转：

			ToString()，转化为字符串

			double.Parse("3.14")转换为3.14存在double里，注意需转换值应与前缀的数值类型对应

#### Class 3

###### 3\.1\.常量const

	const是常量的关键字，可以申明一个常量，常量具有常量名，以及其对应的不可更改的数值，常量在声明的时候就得赋值

	如， const int a = 100;

	常量的赋值形式也有约束，只允许在编译时就已经确定的值，也就是不允许赋未确定的值，比如DateTime.Now等；
	（
	还有更多的例子，new string('a',3)是在代码运行时计算得到了一个字符串'aaa'，所以不能赋值给字符串常量，
	
	同理还有new List<int>()，感觉new函数就是在编译之后运行的，
	
	3*5这种是在编译之前就算完了，所以是可以允许赋值给整数常量的，应该说是所有数值常量-v-，因为隐性转换
	）

	常量相当于给某个数字打上标签，输入常量名要么方便快捷，要么比数字好记，也能清晰程序结构

	常量默认是static的

	static修饰的变量成为静态变量，静态变量属于类型本身，而不是属于某个实例，也就是一个类共用一个静态变量

#### Class 4

###### 4\.1\. 运算符的基本概念

	运算符的分类
	运算符{
		算术运算符{
			+	加		（气笑了，加减法运算符，在计算char和int的和的时候，会自动把char转换位ascII表的对应整数，进行运算，
						尤其注意，你以为在输出函数中，+只起到连接的作用，但是它仍然可以运算）
			-	减
			*	乘
			/	除以（整数会取整）
			%	取模（其实就是取余数）
			++	自增	（顺序为从左往右，a++那么a++在此处用于运算的值为a，因为a在++左，用于运算之后，a再自增）
			--	自减	（顺序同上，a--先用后减，--a先减后用）
		}
		关系运算符{
			==	相等判断
			!=	不等判断
			>	大于判断
			<	小于判断
			>=	大于等于判断
			<=	小于等于判断
		}
		逻辑运算符{
			&&	逻辑与，C#把“非零值为真”这一条禁用了，只允许bool值（可以是语句返还值为bool）
			||	逻辑或
			!	逻辑非，对bool值取反
		}
		位运算符{
			将 byte、sbyte、short、ushort、char 与 int 运算时，小类型自动提升为 int
			将 int 与 long 运算时，int 提升为 long。
			将 uint 与 long 运算时，uint 提升为 long（long 可以表示所有 uint 值）。
			将 ulong 与其他任何有符号整数类型运算时不允许，因为 ulong 不能隐式转换为有符号类型，有符号类型也不能完全表示 ulong。
			上述可进行的一切转换都是隐式转换，即在运算时自动进行
			&	按位与
			|	按位或
			^	按位异或（同则0，异则1）
			~	按位取反
			<<	左移运算（移位运算如果位数溢出则，断位溢出，把溢出数位的数直接裁了，不论是左溢位还是右溢位）
			>>	右移运算（同上）
		}
		赋值运算符{
			=	赋值
			+=	加且赋值
			-=	减且赋值
			*=	乘且赋值
			/=	除且赋值
			%=	求模且赋值
			<<= 左移且赋值
			>>= 右移且赋值
			&=	按位与且赋值
			^=	按位异或且赋值
			|=	按位或且赋值
		}
		其他运算符{
			sizeof()	返还数据类型大小（以B为单位，1字节8位）如，sizeof(byte)，返还4
			typeif()	返还类型的Type对象
			?:		三目运算符，例子：(3>5)?10:20，其实就是一个(bool)?():()，冒号两边类型保持相同即可，可以是任意类型
					bool为true，则取前，bool为false则取后
			is		判断对象是否为某一类型，若是则返回true；否则返回false
			as		强制转换，转换成功返回该对象；转换失败返回null
		}
	}

###### 4\.2\.运算符优先级

	1\.括号
	2\.单目 ++ -- ! ~
	3\.乘除模 * / %
	4\.加减
	5\.比较（不含等号判断）
	6\.相等性检查 == !=
	7\.逻辑与/或
	8\.赋值

#### Class 5

###### 5\.1\.判断语句

	if语句	if(bool){}	（如果不加大括号，那就只执行最近的那个语句）

	if-else语句	
		if(bool)
		{
			//bool==true时运行
		}
		else
		{
			//bool==false时运行
		}
	else只与最近的if配对

	if-else嵌套 让if作为else时的运行语句，也就是else if结构

	switch语句
		switch(变量)
		{
			case 值1:break;
			case 值2:break;
			case 值3:break;
			……
			default:break;
		}
		当变量值等于值1、值2、值3的某一个的时候，执行该行，值之间相等时会报错
		不写break会报错，或者说没有跳出case/default的语句，会直接报错
		只有一种情况不会报错，示例如下：
			switch (month) 
			{
			   case 12:
				case 1:
				case 2:
					Debug.Log("冬季");
					break;
			}
			该情况下case为空，空case自动向下滑落，即往下执行语句，最终12，1，2都执行都一段语句，打出冬季
		可以用goto连接两个case，比如：	
			case 值1: Debug.Log("1");goto case 值2;
			case 值2: Debug.Log("2");break;
			在这种情况下执行case 值1一定执行case 值2
		当任何值都不等于的时候，执行default
		不一定需要又default，没有default时，如果变量不等于任何值，那么直接跳过switch
		值可以是任何类型

	三元运算符：
		变量 = (bool)?值1:值2; 只要保证值1和值2类型相同即可，true取值1，false取值2

###### 5\.2\.循环语句

	*for循环* 
		for (初始化;条件;状态改变){}
		其中初始化只执行一次，条件判断执行在代码块前，状态改变执行在代码块内的末尾
		初例：
			for(int i = 100; i < 149; i++)
			{
				Debug.Log(i);
			}
		输出值为100~148，
		当然i不一定需要在for语句中定义
		
		第一个输出值为100，所以i++不是在Debug.Log(i)前执行的，
		
		最后一个输出值为148，所以if(i<149)是在Debug.Log(i)前执行的，
		
		由于在以下例子中，不输出任何值：
			for(int i = 100; i < 0; i++)
			{
				Debug.Log(i);
			}
		所以，并不是在上一次循环的末尾执行条件语句，来判断下一次循环是否需要发生，在第一个代码块执行前就已经经过一次判断了

		由于在for语句后调用i显示i未声明，可知这里形成了一个代码块

		由于以下程序返回值为149：
			int i ;
			for (i=100; i < 149; i++){}
			Debug.Log(i);
		所以i++是if{}内执行的

		由于for循环接受return等提前退出，所以结构主体是封闭的，其实代码块也行：
			{
				int i =100;
				start:
				if (!(i<149)) goto end;
				Debug.Log(i);
				i++;
				goto start;
				end:
			}

		或者仍然是靠if实现：
			{
				int i = 100;
				back:
				if (i<149) 
				{
					Debug.Log(i);
					i++；
					goto back;
				}
			}
		back是行标签，行标签只存活在代码块内，同时不能跨文件，和变量名的规则一模一样，但不占任何附加空间

	*foreach循环*
		foreach(var <变量名> in <集合名>)
		{
			//循环体
		}
		//特别说明var实际上是定义隐式局部变量，说白了就是看上下文确定变量应该是什么类型的，并且按这个应该的类型进行声明
	暂不知道怎么展开

	*while循环*
		while(bool)
		{
			//循环体
		}
		展开为：
			{
				start:
				if(!bool) goto end;
				//循环体
				goto start;
				end:
			}
		或者：
			{
				back:
				if(bool)
				{
					//循环体
					goto back;
				}
			}

	*do-while循环*
		do
		{
			//循环体
		}while(bool);
		展开为：
			{
				back:
				//循环体
				if(bool) goto back;
			}

	*循环控制语句*{
		break语句		直接终止循环，在编译时就已经规定好了，只认for,while,do while,foreach,switch，5种父结构，并且只作用于从内向外最近的结构
		continue语句	跳过当前迭代，进入下一次循环,只认for,while,do while,foreach，4种父结构，并且只作用于从内向外最近的结构
		在不承认的父结构中，编译器会直接报错
	}

#### Class 6

###### 6\.1\.枚举Enum的基本概念

	定义：枚举Enum是一种值类型，Enum用于定义一组命名的常量为一类，常量间用逗号隔开而非分号，后文深入解释

	限制：只能在类内或global内定义，不能在方法内定义

	目的：提高代码可读性和可维护性，等于给数据加注释

	存储；默认基于int类型，可显示指定其它整型（只能是整型）

	public enum WeekDays : int	//继承int类型，但这是默认的
	{
		None,		//0
		Monday,		//1
		Tuesday,	//2
		Wednesday,	//3
		……
	}
	建议是给一个None，作为占位符
	枚举内的常量可以自己定值，默认为上一个值+1，
	public enum WeekDays : int
	{
		None = 10,		//10
		Monday,			//11
		Tuesday = 20,	//20
		Wednesday,		//21
		……
	}
	这实际上分两步进行，首先先定义了一种类型，这种类型是WeekDays，它继承自System.enum，储存基于int，其次给这个类型划了一个取值范围，也就是用WeekDays声明的None，Monday等常量，有自己的默认初始值
	由WeekDays声明的函数只能取到WeekDays定义的范围中的值，如None等

	Debug.Log输出枚举值时，枚举值隐式转换为object，object通过Debug.Log输出时会调用ToString方法，所以最后会出现的是枚举成员名

	如果想输出枚举值时，要用显式转换Debug.Log((int)WeekDays.Monday);

###### 6\.2\.枚举Enum的高级定义

	[Flags]介绍

		用途
			
			标记枚举类型为位字段，允许（|、&、^等）组合或检查多个枚举值，表示复合状态或选项集合。

		底层实现原理

			每个枚举成员值默认按2的幂次分配，确保二进制位独立，便于位运算处理

		基础类型限制
			
			[Flags]枚举的底层类型必须是整型（如int\byte）

		成员分配规则

			首个成员建议设为None=0、表示空状态

			后续成员值需为2的幂次以支持位运算

		例：

		[Flags]
		public enum FileAccess:byte
		{
			None = 0,
			Read = 1,
			Write = 2
		}
		反正只要在定义枚举类之前加上[Flags]进行标记就行了

	位运算操作（下述标志实指某一位为1的值）

		组合多个枚举值，按位或，	1|2==3（00000001 | 00000010 == 00000011）

		检查特定标志，按位与，		3&1==1（00000011 & 00000001 == 00000001）

		移除标志，&~组合，			3 & ~2（00000011 & ~00000010 == 00000001）

###### 6\.3\.枚举Enum的赋值与转换

	前文有提，枚举储存的值实际上是2进制编码，它可以隐式转换为int，因为它基于int储存，但实际上不是int

	所以Enum WeekDays声明的常量值，得用WeekDays声明的常量承接

	借WeekDays中的值，给其他常量赋值的方法：

		WeekDays day = Enum.Parse<WeekDays>("Monday");
			//Enum.Parse是将字符串转化为枚举值，目标字符串是"Monday"
			//<WeekDays>意思是用查找的方式转换，即在WeekDays枚举类内，查找到常量名为"Monday"的那个，取其枚举值
			//如果查找不到直接报错，抛出ArgumentException
			//将转换后的值赋予day

	枚举转整数

		int value = (int)WeekDays.Monday;

	整数转枚举

		WeekDays day = (WeekDays)1;

###### 6\.4\.遍历枚举

	foreach (WeekDays day in Enum.GetValues( typeof(WeekDays)) )
	{
		Console.WriteLine(day);//同样会调用ToString方法，所以只输出名称，unity中用Debug.Log(day)
	}
	//Enum.GetValues() 作用是把作用对象的所用数值取出来，存到一个数组里
	//(typeof(WeekDays))是表明操作对象是WeekDays枚举类型，其返还值是类型整体
	//所以Enum.GetValues( typeof(WeekDays))返回值是一个WeekDays数组，其排列顺序等同于定义时的顺序

###### 6\.5\.枚举总结及注意事项

	枚举主要承担的是数据存储的任务，只需往外调用，不需要在程序中变动

	枚举在定义的时候就确定了枚举内成员，不能更改

	枚举可以在类内定义，也可在global下定义，只是一个级别的划分

	枚举定义的枚举类型可以用来声明变量，这个变量用来承接对应类型的数据，用于将枚举内的数据输出

	Enum.GetValues(<枚举类>)是专门为枚举创建的函数，用于生成一个对应结构的数组来按顺序承接枚举值

	Enum.Parse<枚举类>("某一枚举成员名")是专门为枚举创建的函数，用于靠枚举成员名查找枚举成员值

#### Class 7

###### 7\.1\.字符串string基本概念

	string是字符串的关键字

	字符串属于引用类型

	字符串在内存中表现为不可变的只读字符集合，修改操作会生成新对象而非修改原对象，原对象直接删除（Stringbuilder可以规避修改的影响）

###### 7\.2\.字符串的初始化

	直接赋值：string s = "text";

	构造函数：通过char[]初始化，如 new string(new[]{'t','e','x','t'})
	（在上述代码中，new[]{'t','e','x','t'}，是隐式生成一个数组，数组类型会自动判定，由于后跟't'，故创建一个char数组，要求大括号内的数据类型一致）
	（new string()的作用是将一个char数组，改为一个字符串类型数据）

	初始为空值的处理：可用null、string.Empty或""，即，s=null/string.Empty/""

###### 7\.3\.字符串的方法

	常用方法{
		1\.获取长度{
			关键字：Length，
				用法：	字符串.Length，
				返还值：该字符串的长度，也就是字符数
				例：	"abc".Length 返还 3
			}
		2\.大小写转换{
			关键字：ToUpper()/ToLower()
				用法：	字符串.ToUpper()/ToLower()
				返还值：一个新的字符串，原本没大写的全部大写
				例：	"Abc".ToUpper() 返还 "ABC"
		}
		3\.子字符串操作{
			关键字：Substring()
				用法:	字符串.Substring(int start,int length)，从start+1位开始，包含在内往后取length位
				返还值：取到的字符串
				例：	"Hello".Substring(1,3) 返还 "ell"
			关键字：Remove()
				用法：	字符串.Remove(int start, int length)，从start+1位开始，包含在内往后的length被剔除
				返还值：剔除后的字符串
				例：	"Hello".Remove(1,3) 返还 "Ho"
		}
		4\.查找替换{
			关键字：IndexOf()
				用法:	字符串.IndexOf(string value)//记住，这个是string value
				返回值：查找的字符串结构首字母的坐标值
				例：	"Hello".IndexOf("el") 返还 1
			关键字：Replace()
				用法:	字符串.Replace(old,new)//记住，这个old和new也是string value
				返回值：替换后的整体
				例：	"Hello".Replace("ello","appy") 返还 "Happy"
		}
		5\.分割与合并{
			关键字：Split()
				用法：	字符串.Split(char[]separator);//char[]separator是一个char型数组，你可以在里面加入任何作为拆分符的东西
				返回值：拆分后的各部分存到一个string数组里，返还该数组
				例：	"a,b、c".Split(new char[]{',','、'}); 返还 ["a","b","c"]
					或者"a,b、c".Split(',','、'); 返还 ["a","b","c"]
					上下两个是等价的，下面的是用params特性简写
			关键字：string.Join()
				用法：	string.Join(string separator, 按顺序装填的一个string数组)
				返回值：按顺序把提供的string数组的各部分用sepatator符号连接起来
				例：	string[] words = new string[] { "a", "b", "c" };
						string.Join("-", words);
						返还 "a-b-c"
			Split和string.Join显然是有联动的，可以用来换分隔符
		}
		6\.比较{
			==:就是逐位相等判断
			string.Equals(a,b,StringComparison.Ordinal)
				//这是静态用法，比较a，b两个字符串是否相等
				//StringComparison是第三项的一个比较方法参数，其下有StringComparison.Ordinal注意大小写，StringComparison.OrdinalIgnoreCase忽略大小写;StringComparison.CurrentCulture按文化映射来
			a.Equals(b,StringComparison.Ordinal)
				//这是实例用法，一个参数是比较对象，第二个参数是比较方法
			返回值都是bool
		}
		7\.移除首尾空白符{
			关键字：Trim()
				用法：	实例用法
				返回值：去掉首尾所有空白符
			关键字：TrimEnd()
				用法：	实例用法
				返回值：只去掉尾所有空白符
		}
		8\.连接
			+：字符串放两边就好，按顺序连接
	}