﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Maui
{
	public class PositionInfo : IPositionInfo
	{
		internal static PositionInfo ForHeader(int position)
			=> new() { Position = position, Kind = PositionKind.Header };

		internal static PositionInfo ForFooter(int position)
			=> new() { Position = position, Kind = PositionKind.Footer };

		internal static PositionInfo ForSectionHeader(int positon, int sectionIndex, int itemsInSection = 0)
			=> new()
			{
				Position = positon,
				Kind = PositionKind.SectionHeader,
				SectionIndex = sectionIndex,
				ItemsInSection = itemsInSection
			};
		internal static PositionInfo ForSectionFooter(int position, int sectionIndex, int itemsInSection = 0)
			=> new()
			{
				Position = position,
				Kind = PositionKind.SectionFooter,
				SectionIndex = sectionIndex,
				ItemsInSection = itemsInSection
			};

		internal static PositionInfo ForItem(int position, int sectionIndex, int itemIndex, int itemsInSection, int numberOfSections, bool selected = false)
			=> new()
			{
				Position = position,
				Kind = PositionKind.Item,
				SectionIndex = sectionIndex,
				ItemIndex = itemIndex,
				ItemsInSection = itemsInSection,
				NumberOfSections = numberOfSections,
				IsSelected = selected
			};

		internal int Position { get; set; } = -1;

		internal int ReuseId { get; set; }

		public PositionKind Kind { get; set; } = PositionKind.Item;

		public int SectionIndex { get; set; } = -1;

		public int NumberOfSections { get; set; } = 0;

		public int ItemIndex { get; set; } = -1;

		public int ItemsInSection { get; set; } = 0;

		public bool IsSelected { get; set; } = false;

		public bool IsLastItemInSection => ItemIndex >= ItemsInSection - 1;
		public bool IsNotLastItemInSection => !IsLastItemInSection;
		public bool IsFirstItemInSection => ItemIndex == 0;
		public bool IsNotFirstItemInSection => !IsFirstItemInSection;

		public override int GetHashCode()
			=>	(ItemIndex, SectionIndex, NumberOfSections, IsSelected, ItemsInSection, Kind, ReuseId, Position).GetHashCode();
	}
}
