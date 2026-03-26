namespace Mintos.API;

/// <summary>
/// Request body for primary (set-of-notes) marketplace listing.
/// Schedule types are string tokens (e.g. full, partial), unlike the secondary market numeric bitmask.
/// </summary>
public class PrimaryMarketNoteSeriesRequest : NoteSeriesSearchRequestBase
{
	public string[]? ScheduleTypes { get; set; }
}
