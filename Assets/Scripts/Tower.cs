using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	private float range = 3.0f;
	private float attack_speed = 1.0f;
	//private int level = 0;
	private Transform m_transform;
	public GameObject prefab;
	public GameObject m_target;
	private float m_time;

	public GameObject FindEnemies()
	{
		float min_dist = 0;
		m_target = null;
		ArrayList m_enemies = GameManager.Instance.enemies;
		//遍历每个敌人
		foreach (Enemy enemy in m_enemies) {
			//忽略生命值为0的敌人
			//if(.HP==0) continue;
			//计算防守单位与敌人间的距离
			Vector3 mPos1 = m_transform.position;
			Vector3 mPos2 = enemy.transform.position;
			float mDis = Vector2.Distance (new Vector2 (mPos1.x, mPos1.y), new Vector2 (mPos2.x, mPos2.y));
			if (mDis > range) {
				//Debug.Log("敌人" + _enemy.transform.name + "未进入攻击范围,距离为:" + mDis);
				continue;
			} else {
				//Debug.Log("敌人" + enemy.transform.name + "已进入攻击范围,距离为:" + mDis);

				if (min_dist == 0 || min_dist > mDis) {
					m_target = enemy.gameObject;
					min_dist = mDis;
				}
			
				/*//选择生命值最低的敌人
			if(mLife==0 || mLife > _enemy.HP){
				mTarget=_enemy;
				mLife=_enemy.HP;
			}
			*/
			}
		}
		return m_target;

	}

//	void Attack ()
//	{
//		m_time -= Time.deltaTime;
//		Debug.Log (m_time);
//		if (m_time <= 0) {
//			m_time = attack_speed;
//			GameObject m_bullet = (GameObject)Instantiate (prefab, this.transform.position, Quaternion.identity);
//			//m_bullet.transform.position = Vector3.MoveTowards (m_bullet.transform.position, 
//			//                                                  m_target.transform.position, 40 * Time.deltaTime);
//		}
//	}


	void Awake()
	{
		m_transform = this.transform;

	}
	// Use this for initialization
	void Start () {
		m_time = attack_speed;
		prefab = (GameObject)Resources.Load ("Bomb");
	}
	
	// Update is called once per frame
	void Update () {
	}


}
