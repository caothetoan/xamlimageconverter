namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// The SvgPolygonElement interface corresponds to the 'polygon' element
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>100</completed>
	public interface ISvgPolygonElement	: 
		ISvgElement,
		ISvgTests,
		ISvgLangSpace,
		ISvgExternalResourcesRequired,
		ISvgStylable,
		ISvgTransformable,
		/*org.w3c.dom.events.EventTarget,*/
		ISvgAnimatedPoints
	{

	}
}
