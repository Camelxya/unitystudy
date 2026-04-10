	1.Lambda语句（简易定义一个匿名方法）
		((参数列表)) => {参数处理逻辑}
		例:	（int x, int y）=> x+y

	2.委托Delegate（用+=和-=增删方法，其储存的是方法名，所以不需要()）
		(public) delegate (返回值类型) (委托名) ((参数列表));
		例：public delegate void Delegate (int i);
		用委托名声明，用new或赋值方法名的方式实例化，可以直接不实例化，用+=的方式增加成员

	3.事件Event（用+=和-=增删方法，其储存的是方法名，所以不需要()）
		(public) event (用来定义该事件的委托名) (事件名);
		例:	public delegate void Delegate (int i);
			public event Delegate Event;
		事件实际上是一种特殊的委托，只能由委托所属类进行触发，其它类内的函数只能通过其所属类进行调用，实际上是一种封装

	4.匿名方法（用于给委托增加方法）

	5.InvokeRepeating("方法名",<延时出发时间，默认单位秒>，<方法重复执行的间隔，默认单位秒>)

	6.运算符重载
		一元运算符，二元运算符，比较运算符可以进行重载
		定义格式:	public static （返回值类型） operator(重载运算符) ((参数列表)){return （返回值）}
		例:			public static double operator+ (int i, int j){return i-j}
		参数与运算符的左右关系，和参数列表的先后关系对应，尤其减法是前一个参数减后一个参数

	7.异常处理，把可能有问题的语句用try{}包裹起来，里面的语句会被执行，用catch去捕获异常（如果有），系统有默认的几个异常分类，如果捕获到了异常，那就执行catch语句下{}包起来的部分，finally{}会在try语句结束后执行

	8.预处理器指令，
		#region，#endregion分割代码块，可以在IDE里折叠代码
		#warning & #error 在编译时提示开发人员注意特定问题
		#if 宏名1
			Debug.Log("");
		#elif 宏名2
			Debug.Log("");
		#else
			Debug.Log("")
		#endif
		等指令可以在开发和生产环境中编译不同的代码，方便调试和发布

	9.命名空间

	10.ref和out
		C#中用于按引用传递参数的关键字
		共同点：
			均通过传递变量的内存地址实现
			适用于值类型和引用类型
		差异性：
			参数初始化要求
				ref调用前必须显示初始化
				out调用前无需初始化
			方法内赋值要求
				ref可读可写
				out必须在方法内完成赋值
		值传递时会复制整个值到栈内存中，方法内部操作的是副本，原始变量不受影响
		引用类型传递的是栈中的指针，会直接修改堆内存中的数据，也就是会影响原始变量

		用ref传递的值变量，会直接将原始变量导入方法
			int a = 0;
			void Process (ref int data)
			{
				data += 10;
			}
			Process(ref a);
			Debug.Log(a);
			此时输出的不是0，而是10
			在方法定义和方法调用时都需要加关键字
			ref和out构不成重载

		void exchange(ref int a, ref int b, out int c)
		{
			c=a+b;
			b=c-b;
			a=c-a;
		}
		int Sum;
		int value1=1;
		int value2=2;
		exchange(ref value1, ref value2, out Sum);

	11.StringBuilder类型
		变量型string，
		StringBuilder sb1 = new StringBuilder((空间大小，默认16个字符，可直接输入字符串))
		能隐式两倍扩容

		string s = "Hello World";
		StringBulider sb = new StringBuilder(s);
		sb.Clear();
		for (int i = s.Length - 1; i>=0; i--)
		{
			sb.Append(s[i]);
		}
		Debug.Log(sb.ToString());

	12.文件管理
		静态工具类{
			File类{
				File.Create("文件名含后缀")						创建
				string s = File.ReadAllText("文件名含后缀");	读取
				File.WriteAllText("文件名","输入的文本");		覆写
				File.AppendAllText("文件名","输入的文本");		追加
				File.Delete("文件名含后缀");					删除
			}
			Directory类{
				Directory.CreateDirectory("文件夹名")							创建
				string[] files = Directory.GetFiles("文件夹名", "*.文件后缀");	读取某一后缀文件
			}
		}
		实力类{
			FileInfo类{
				得先创建FileInfo实例，来盛装文件
			}
			DirectoryInfo类{
				得先创建DirectoryInfo实例
			}
		}

		读写
			文本文件	StreamWriter StreamReader（实例），用using语句
				using语句:
					using(StramWriter writer = new StreamWriter("文件名含后缀")
					{	
						操作主体
					}
			二进制文件	FileStream创建文件对象，用BinaryWriter\BinaryReader正对FileStream对象创建写入\只读对象，也用using语句

		用using自动释放内存

		string path = Application.dataPath + "/4.10/file.text";

		string input = "你好，Unity";
		byte[] bytes = Encoding.UTF8.GetBytes(input);
		using(FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
		{
			fs.Write(bytes, 0 ,bytes.Length);
		}

		AssetDatabase.Refresh();
		Debug.Log("文件写入完成");

	调试
		F5:	执行至断点
		F10:单步调试
		F11:进入代码内部
		F9:	在此处增加断点