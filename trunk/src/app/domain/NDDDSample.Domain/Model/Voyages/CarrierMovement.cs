﻿namespace NDDDSample.Domain.Model.Voyages
{
    #region Usings

    using System;
    using Locations;
    using Shared;
    using TempHelper;

    #endregion

    /// <summary>
    /// A carrier movement is a vessel voyage from one location to another.
    /// </summary>
    public class CarrierMovement : IValueObject<CarrierMovement>
    {
        public static CarrierMovement NONE = new CarrierMovement(
            Location.UNKNOWN, Location.UNKNOWN, new DateTime(0), new DateTime(0));

        private readonly Location arrivalLocation;
        private readonly DateTime arrivalTime;
        private readonly Location departureLocation;
        private readonly DateTime departureTime;
        protected long id;

        // Null object pattern 


        /// <summary>
        /// Constructor.
        /// TODO make package local
        /// </summary>
        /// <param name="departureLocation">location of departure</param>
        /// <param name="arrivalLocation">location of arrival</param>
        /// <param name="departureTime">time of departure</param>
        /// <param name="arrivalTime">time of arrival</param>
        public CarrierMovement(Location departureLocation,
                               Location arrivalLocation,
                               DateTime departureTime,
                               DateTime arrivalTime)
        {
            Validate.noNullElements(new object[] {departureLocation, arrivalLocation, departureTime, arrivalTime});
            this.departureTime = departureTime;
            this.arrivalTime = arrivalTime;
            this.departureLocation = departureLocation;
            this.arrivalLocation = arrivalLocation;
        }

        protected CarrierMovement()
        {
            // Needed by Hibernate
        }

        #region IValueObject<CarrierMovement> Members

        /// <summary>
        /// Value objects compare by the values of their attributes, they don't have an identity.
        /// </summary>
        /// <param name="other">The other value object.</param>
        /// <returns>true if the given value object's and this value object's attributes are the same.</returns>
        public bool SameValueAs(CarrierMovement other)
        {
            return other != null && new EqualsBuilder().
                                        Append(departureLocation, other.departureLocation).
                                        Append(departureTime, other.departureTime).
                                        Append(arrivalLocation, other.arrivalLocation).
                                        Append(arrivalTime, other.arrivalTime).
                                        IsEquals();
        }

        #endregion

        #region Object's overrides

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var that = (CarrierMovement) obj;

            return SameValueAs(that);
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder().
                Append(departureLocation).
                Append(departureTime).
                Append(arrivalLocation).
                Append(arrivalTime).
                ToHashCode();
        }

        #endregion

        /// <summary>
        /// Departure location.
        /// </summary>
        /// <returns></returns>
        public Location DepartureLocation()
        {
            return departureLocation;
        }

        /// <summary>
        /// Arrival location.
        /// </summary>
        /// <returns></returns>
        public Location ArrivalLocation()
        {
            return arrivalLocation;
        }

        /// <summary>
        /// Time of departure.
        /// </summary>
        /// <returns></returns>
        public DateTime DepartureTime()
        {
            //TODO: atrosin : new Date(arrivalTime.getTime());
            return departureTime;
        }

        /// <summary>
        ///  Time of arrival.
        /// </summary>
        /// <returns></returns>
        public DateTime ArrivalTime()
        {
            //TODO: atrosin : new Date(arrivalTime.getTime());
            return arrivalTime;
        }
    }
}