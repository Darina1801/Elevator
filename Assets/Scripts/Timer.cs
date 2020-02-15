using UnityEngine;

/// <summary>
/// A timer
/// </summary>
public class Timer : MonoBehaviour
{
	#region Fields
	
	// timer duration
	private float totalSeconds = 0;
	
	// timer execution
	private float elapsedSeconds = 0;
	private bool running = false;
	
	// support for Finished property
	private bool started = false;
	
	#endregion
	
	#region Properties
	
	/// <summary>
	/// Sets the duration of the timer
	/// </summary>
	/// <value>duration</value>
	public float Duration
    {
		set
        {
			if (!running)
            {
				totalSeconds = value;
			}
		}
	}
	
	/// <summary>
	/// Gets whether or not the timer has finished running
	/// </summary>
	/// <value>true if finished; otherwise, false.</value>
	public bool Finished
    {
		get { return started && !running; } 
	}
	
	/// <summary>
	/// Gets whether or not the timer is currently running
	/// </summary>
	/// <value>true if running; otherwise, false.</value>
	public bool Running
    {
		get { return running; }
	}

    #endregion

    #region Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {	
		// update timer and check for finished
		if (running)
        {
			elapsedSeconds += Time.deltaTime;
			if (elapsedSeconds >= totalSeconds)
            {
				running = false;
			}
		}
	}
	
	/// <summary>
	/// Runs the timer
	/// </summary>
	public void Run()
    {	
		if (totalSeconds > 0)
        {
			started = true;
			running = true;
            elapsedSeconds = 0;
		}
	}

	/// <summary>
	/// Stops the timer 
	/// </summary>
	public void Stop()
	{
		started = false;
		running = false;
		elapsedSeconds = 0;
	}

	/// <summary>
	/// Restarts the timer
	/// </summary>
	public void Restart()
	{
		Stop();
		Run();
	}
	
	#endregion
}
