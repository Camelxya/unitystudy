	1.F2可以对场景进行重命名

	2.模型
		1）	模型本身是由“顶点组成的网格数据”，本身不存在颜色
		2）	材质决定模型的实际外观，由于我们使用的是内置模型，和模型一样，材质也是一种资源，默认材质白
		3）	Mesh Filter：网格过滤器，确定形状
			Mesh Renderer：网格渲染器{
				Materials：材质{
					材质数量
					材质具体，None材质在Scene中体现为紫红色，即渲染出错
					材质是.mat文件
				}
			}
		4）	模型处理：改变Transform组件的数值{
				组件涵盖{
					position位置
					rotation角度
					scale缩放倍数
				}
				切回默认：Reset
				模型移动{
						父子物体整体移动{
							质心{
								Pivot 父物体中心
								Center 组合体中心
							}
							参考系{
								Local 父物体为参考系搭建坐标系
								Global 按照世界参考系来
							}
						}	
					}
				模型拉伸：父物体的变化会引起子物体变化
				模型约束：按住Ctrl进行操作，可以按默认跨度移动（在Edit-Grid and Snap(网格和吸附)下编辑）
				模型吸附：按住V
				快速定位：按F
			}

#### Class1 组件思想

###### 1\.1\. 自定义组件

	1\.组件不可重名

	2\.若未特殊设定，同一组件可以多次添加到同一物品

	3\.MonoBehaviour的派生类都是组件

	4\.组件的学习方法：从Inspector面板学习，在C#脚本中学习

###### 1\.2\. Transform

	1\.主要变量

		Position位置	用结构体Vector3储存的信息

		Rotation角度	用结构体四元数 Quaternion (x,y,z,w)承接，其中x默认为0，旋转矩阵为（cos(i/2),usin(i/2)），i为旋转角，u为旋转轴（x默认为0）
						因为x,y,z在欧拉角里面是有先后关系的，绕x转会带动y、z，绕y轴转只会带动z，顺序在前的轴只会带动顺序在后的轴，所以在绕y轴转动90°后，变换后的z轴和变换前的x轴重合了，所以失去了一个自由度（这实际是程序运算顺序导致的结果，因为当你填写角度时，是相对初始状态的变化）

		localScale缩放倍数

	2\.重要信息

		层级信息（即父子关系）

	//print等价Debug.Log

	3\.常用属性和方法

		子物体的数量，childCount
		父物体的Transform，parent，返还值为父物体名
		最高级的Transform，root
		eulorAngles，欧拉角
		localScale，缩放值

		Find(string);查找子物体
		Translate(Vrctor3);朝着一个坐标移动，等效于 transform.position + Vector3;
		Rotate(Vector3);旋转一个角度（用欧拉角）
		LookAt(Transform);看向目标

###### 1\.3\. GameObject

		组件可以直接用gameObject属性访问到，当前组件所属物品的GameObject

		Transform类，GameObject类中都有继承到transform和gameObject属性，所以Transform可以得到Gameobject信息，反之亦然

		常用属性：
			name	名字
			tag		标签
			activeInHierarchy	显示状态，是个bool值
			transform

		常用方法：
			static GameObject Find(string path); 一个静态方法，查找游戏物体，从根目录开始查起，子物体要含带父物体，比如"C/D"
			GetComponent<需要获取的组件名>();	获取游戏物体上的组件，需要用对应的组件类进行盛装，不能取GameObject，它不算组件
			SetActive(bool值)：	设置可见

###### 1\.4\. 预制体Prefabs

	把GameObject拖入Project，可制作一个预制体（含有其带有的组件）

	把预制体拖回Hierarchy或Scene中，可做到复用

	预制体的复用，类似引用类型，进入异世界，改变预制体，所有复用的都会改变（包括原本）

	异世界由Hierarchy预制体右侧箭头进入，或双击Project里的预制体

	预制体被删除后，其复用仍然保留，但名字会变成红色表示引用关系丢失，可右键Unpack Prefab

	预制体内可以嵌套预制体，但是原始操作不影响别的预制体中的复用，因为被异世界中的操作覆写了

	预制体的组件改变，如果没有进入异世界进行，那么该改动可以反悔，在Inspector窗口的页头，右下角的Overrides

	变体：
		预制体的复用也可以被拉入Project，成为新的预制体，其中有两个选项：
			原始预制体：完全独立的预制体
			预制体变体：旧的预制体变化，变体也会变化，但是变体保留和旧预制体不同的部分（也就是保留新覆写的那一部分，同嵌套预制体）

###### 1\.5\. 生命周期函数

	Awake()			第一次唤醒的时候，执行一次
	OnEnable()		每次启用都执行一次
	Start()			开始事件，执行一次
	FixedUpdate()	固定更新事件（逻辑帧），执行N次，0.02s执行一次。所有物理相关的更新都在这个事件中处理
	Update()		每个渲染帧刷新一次
	LateUpdate()	稍后更新事件，执行N次，在Update()后执行
	OnDisable()		禁用时执行一次
	OnDestroy()		销毁事件时执行一次

	Time.deltaTime	渲染上一帧所用时间

###### 1\.6\. Invoke函数

	Invoke("方法名",(延迟执行时间，默认单位秒，float格式));
		延迟执行

	InvokeRepeating("方法名",(延迟执行时间，默认单位秒，float格式),(间隔时间));
		延迟后，每间隔执行一次

	CancelInvoke("方法名");
		取消某被Invoke执行的函数

###### 1\.7\. 协程

	public IEnumerator Demo(int numX)
	{
		while(true)
		{
			yield return new WaitForSeconds(时间);	//暂停运行几秒
			transform.Rotate(new Vector3(5,0,0));
		}
	}

	void Start()
	{
		StartCoroutine(Demo(2));
	}

	StartCoroutine(协程函数);	执行（返还值是一个Corountine类型），可以直接用 Corountine cor = StartCorountine(协程函数);来承接
	StopCoroutine(协程函数/承接协程的Corountine);	停止

###### 1\.8\. 常用工具类

	Mathf.{
		Abs		绝对值
		Max
		Min
		Round	四舍六入，五取大一位的相邻的偶数
		Ceil	向上取整
		Floor	向下取整
		Random.Range()	返回随机值{
			int a = Random.Range(0,5);	含下界不含上界[0,4]
			float a = Random.Range(0,5.0f);	含上下界[0,5]
		}	
	}

	Time.{
		只读：
		time	运行的游戏时间
		deltaTime	表示上一帧到当前帧的游戏时间，单位秒
		realtimeSinceStartup	从游戏开始后的现实时间，暂停的时长也算进去

		读写：
		timeScale	时间缩放，默认1，0是暂停，负数是拉长为原本的几倍，但其实直接用正数可以实现全部功能（用赋值语句实现，Time.timeScale = 0;游戏时间和渲染帧是并行不相干的，改变的是deltaTime）
	}

#### Class 2 2DUnity

###### 2\.1\. Sprite 和 SpriteRenderer

	将 Main Camera 的 Camera 组件中的 Projection 调成 Orthographic 也就是正交（取消近大远小）

	Sprite 是 unity 内部生成的文件，不是图片本身，是由图片生成的

	multiple 用于将一张图片分割为不同 sprite

	图片的参考点 Pivot 在切割的时候可以集体设定

	SpriteRenderer组件{
		Sprite，选择图片作为精灵生成的源
		Color，叠加颜色，给西瓜原有颜色加上一层滤镜（除RGB外，还有A，透明度）
		Flip，翻转，按X轴和Y轴反转
		Sorting Layer，渲染层级，越下方渲染优先级越高
		Order in Layer，同渲染层级，数字大的先渲染
	}

###### 2\.2\. Rigidbody 2D

	在 Edit - Project Settings - Rigidbody 2D 中可以调整内部参数

	BodyType 类型，Dynamic 动态，Kinematic 运动，Static 静态

	Simulated 相当于有没有启用

	Mass 质量

	Linear Drag 位移阻尼

	Angular Drag 旋转阻尼

	Gravity Scale 缩放重力

	Collision Detection：Discrete模式会穿模，Continuous模式不会穿模（其实就是运算频率更高）

	Constraints 轴变化约束	Z轴是旋转，XY是移动，可以冻结住某一个轴的移动

	Physical Materials 2D(在create - 2D里) 物理材质：Friction 摩擦系数，Bounciness 弹性倍数（弹起的高度与下落高度的倍数）

	rigidbody2D 是一个保留接口，但是不再支持的api，不要用

	velocity 速度

	AddForce 施加力

	用一个变量来承接
		private Rigidbody2D rb2D;
		rb2D = GetComponent<Rigidbody2D>();

	弹性效果只有在用Rigidbody2D下的方法，比如velocity移动的时候，才能够触发弹力
###### 2\.3\. Collider2D

	Edit （等效于改变Offset偏移量，和Size相对于渲染的等比缩放）

	Material

	碰撞事件

		OnCollisionEnter2D(Collision2D collision)	碰撞进入时执行，每帧执行一次，这里承接的参数是，collision指的是碰撞的过程

		OnCollisionExit2D	碰撞退出时执行，每帧执行一次

		OnCollisionStay2D	碰撞中执行，每帧执行一次

		碰撞事件的触发条件：双方都得有碰撞体，至少一方得有刚体，此时双方都可以触发碰撞事件

	Collision2D

	collision.gameObject 指的是碰撞的对方

	GamObject.Destroy() 静态方法，销毁，最好通过tag进行锁定，方便预制体的程序也能锁定到预制体自身，用name的话会预制体的名字是 原名(clone)，所以指向不到

###### 2\.4\. isTrigger

	这个是 Collider 中的一个选项，勾上后，该物体的碰撞箱模式会切换为触发，即可以与其它碰撞箱重合

		OnTriggerEnter2D(Collider2D collider)	触发进入时执行，每帧执行一次，注意这里承接的参数是，触发过程中的另一个物体的collider组件

		OnTriggerExit2D		触发退出时执行，每帧执行一次

		OnTriggerStay2D		触发中执行，每帧执行一次

#### Class 3 输入获取

###### 3\.1\. 键盘输入

	GetKey("a")，GetKeyUp()，GetKeyDown()	可以用来做蓄力

###### 3\.2\. 鼠标输入
	
	GetMouseButton(1/0); 1是右键，0是左键
	GetMouseButtonUp()
	GetMouseButtonDown()
		可以用来做蓄力

	Input.mousePosition	获取鼠标位置



###### 3\.3\. InputManager

	Edit - ProjectSettings - InputManager

	可以在里面编辑轴名，和返回

	以下函数按下特定按钮有返回值，按钮和返回值由轴名定义
	Input.GetAxis("轴名");		变化过程中有中间值
	Input.GetRawAxis("轴名");	按下按钮后直接突变

	常用轴名：
		"Horizontal"	AD，左右轴，A为-1
		"Vertical"		WS，上下轴，W为1
		"Mouse ScrollWheel"	鼠标滚轮轴，向前为1

