## 1\.Unity和C#概览

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



## 2\.C#专场

###### 1\.类class

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

	**MonoBehavior**是Unity引擎提供的类，包含了很多生命周期的方法
	（
	AWake：实例被加载时调用，用于初始化或设定初始状态。在游戏对象启用之前调用
	OnEnable：当脚本或对象被激活时调用，用于处理对象激活时的逻辑
	Start：在所有Awake()方法调用完成后并且所用游戏对象已启用时调用，用于脚本初始化、游戏逻辑初始化。在第一次Upadate发生之前调用
	Update：每渲染帧调用一次，用于常规的游戏逻辑处理，如输入检测、对象移动
	Destroy：当游戏对象被销毁时调用，用于释放资源或执行清理操作
	等
	）

###### 2\.方法Method（Method并非关键字，而是常用称呼）

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

###### 3\.在unity日志上显示的函数 Debug.Log

	Debug.Log("");输出白色日志（普通）

	Debug.Log("");输出黄色日志（警告）

	Debug.Log("");输出红色日志（错误）

###### 4\.unityC#文件的特殊注意点

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

###### 5\.编码新注意

	必须是英文状态，
	
	方法调用中：
	静态方法用“类名.”+“方法名”来调用
	普通方法用“类对象”+“方法名”来调用

	注释方法
	//<内容>    单行注释
	/*<内容>*/  多行注释