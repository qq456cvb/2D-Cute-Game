using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : qpFollowTargetObject{

	GameObject prefab;
	private Slider m_HPBar;
	private Vector3 m_pos;
	private int m_hp = 100;

	void Awake()
	{
		prefab = (GameObject)Resources.Load ("HPBar");
	}

	// Use this for initialization
	void Start () {
		base.Start ();
		GameManager.Instance.enemies.Add (this);
		Transform mUiRoot = GameObject.Find("Canvas2D").transform;
		m_pos = this.transform.position;
		m_pos.y += 1;
		GameObject go=(GameObject)Instantiate(prefab, m_pos, Quaternion.identity);
		//使血条成为Canvas的子物体
		go.transform.parent = mUiRoot;
		//对血条进行放缩
		go.GetComponent<RectTransform>().localScale=new Vector3(0.01f,0.01f,0.01f);
		//获取Slider
		m_HPBar=go.transform.GetComponent<Slider>();
	}
	

	void Update () {
		base.Update ();
		m_pos = this.transform.position;
		m_pos.y += 1;
		m_HPBar.transform.position=m_pos;
		m_HPBar.value = (float) m_hp / 100;
	}

	public void SetDamage(int damage)
	{
		m_hp -= damage;
		if (m_hp <= 0)
			Destroyself ();
	}

	public void Destroyself()
	{
		Destroy(this.gameObject);
		Destroy(m_HPBar.gameObject);
		GameManager.Instance.enemies.Remove(this.GetComponent<Enemy>());
	}
}
