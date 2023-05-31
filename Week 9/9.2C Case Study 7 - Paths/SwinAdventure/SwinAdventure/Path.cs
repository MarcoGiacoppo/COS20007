using System;

namespace SwinAdventure
{
	public class Path : GameObject
	{
		private Location _destination;
		private bool _isLocked;

		public Path(string[] ids, string name, string desc, Location destination) : base(ids, name, desc)
		{
			_destination = destination;
		}

		public Location Destination
		{
			get
			{
				return _destination;
			}
		}

        public override string FullDescription
		{
			get
			{
				return $"{Destination.Name} is in the {Name}";
			}
		}

		public bool IsLocked
		{
			get
			{
				return _isLocked;
			}
			set
			{
				_isLocked = value;
			}
		}

		public string Move(Player player)
		{
			if (IsLocked)
			{
				return "The path is locked.";
			}
			player.Location = Destination;
			return Destination.Name;
		}
    }
}

