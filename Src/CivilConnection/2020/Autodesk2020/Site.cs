using Autodesk.AECC.Interop.Land;
using Autodesk.DesignScript.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilConnection
{
    /// <summary>
    /// Site object type.
    /// </summary>
    public class Site
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// The Site
        /// </summary>
        internal AeccSite _site;
        /// <summary>
        /// The name
        /// </summary>
        string _name;
        #endregion

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets the handle.
        /// </summary>
        /// <value>
        /// The handle.
        /// </value>
        public string Handle { get { return this._site.Handle; } }
        /// <summary>
        /// Gets the object id.
        /// </summary>
        /// <value>
        /// The object id.
        /// </value>
        public long ObjectId { get { return this._site.ObjectID; } }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get { return this._name; } set { this._name = value; } }
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Initializes a new instance of the <see cref="Site"/> class.
        /// </summary>
        /// <param name="s">The AeccSite.</param>
        internal Site(AeccSite s)
        {
            this._site = s;
            this._name = s.Name;
        }
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// Gets the land feature lines.
        /// </summary>
        /// <returns></returns>
        public IList<LandFeatureline> GetLandFeatureLines()
        {
            Utils.Log(string.Format("CivilDocument.getLandFeatureLines started...", ""));

            IList<LandFeatureline> output = new List<LandFeatureline>();

            foreach (AeccLandFeatureLine fl in this._site.FeatureLines)
            {
                output.Add(new LandFeatureline(fl));
            }

            Utils.Log(string.Format("CivilDocument.getLandFeatureLines completed.", ""));

            return output;
        }

        /// <summary>
        /// Gets land feature line by name.
        /// </summary>
        /// <param name="name">The land feature line name.</param>
        /// <returns></returns>
        public LandFeatureline GetLandFeatureLineByName(string name)
        {
            return this.GetLandFeatureLines().First(x => x.Name == name);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Site(Handle = {0}, ObjectId = {1}, Name = {2})", this.Handle, this.ObjectId, this.Name);
        }

        #endregion
    }
}