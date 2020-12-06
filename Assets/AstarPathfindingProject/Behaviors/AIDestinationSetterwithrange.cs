using UnityEngine;
using System.Collections;

namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetterwithrange : VersionedMonoBehaviour {

		public Transform target;
		IAstarAI ai;
		public float agroRange;
		Rigidbody2D rb2d;
		public Animator anim;
		public float speed;
		private float waiter;
		public float WaitingTime;

		public Transform[] hotspots;
		private int randomSpot;

		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			if (ai != null) ai.onSearchPath += Update;
		}
        private void Start()
        {
			waiter = WaitingTime;
			randomSpot = Random.Range(0, hotspots.Length);
		}
        void Update () {
			float distToPlayer = Vector2.Distance(transform.position, target.position);
            if (distToPlayer < agroRange){
				if (target != null && ai != null) ai.destination = target.position;
				anim.SetBool("move", true);
				anim.SetFloat("velx", (target.position.x - transform.position.x));
				anim.SetFloat("vely", (target.position.y - transform.position.y));
			} 
			else{
				ai.destination = hotspots[randomSpot].position;
				if (Vector2.Distance(transform.position, hotspots[randomSpot].position) < 0.2f){
                    if (waiter <= 0)
                    {
						randomSpot = Random.Range(0, hotspots.Length);
						waiter = WaitingTime;
					}
                    else
                    {
						waiter -= Time.deltaTime;
                    }
                }
				anim.SetBool("move", true);
				anim.SetFloat("velx", (hotspots[randomSpot].position.x - ai.position.x));
				anim.SetFloat("vely", (hotspots[randomSpot].position.y - ai.position.y));
			}
		}
	}
}
