using Core.Entities;
using Core.Request;
using Core.Response;

namespace Core.Interfaces.Services
{
    public interface IPlaneService
    {
        /// <summary>
        /// Retrieves a list of planes paginated by the specified page number and page size.
        /// </summary>
        /// <param name="page">The page number to retrieve.</param>
        /// <param name="size">The number of items per page.</param>
        /// <returns cref="MainResponse{PlaneResponse}">
        /// A MainResponse containing a paginated list of PlaneResponse objects if successful, 
        /// otherwise, a MainResponse with the appropriate error message.
        /// </returns>
        Task<MainResponse<IEnumerable<PlaneResponse>>> GetPlanesByPage(int page, int size);

        /// <summary>
        /// Retrieves a list of availables planes paginated by the specified page number and page size.
        /// </summary>
        /// <param name="page">The page number to retrieve.</param>
        /// <param name="size">The number of items per page.</param>
        /// <returns cref="MainResponse{IEnumerable{PlaneResponse}}">
        /// A MainResponse containing a paginated list of PlaneResponse objects if successful, 
        /// otherwise, a MainResponse with the appropriate error message. 
        /// </returns>
        Task<MainResponse<IEnumerable<PlaneResponse>>> GetAvailablePlanesByPage(int page, int size);

        /// <summary>
        /// Retrieves a plane by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the plane to retrieve.</param>
        /// <returns cref="MainResponse{PlaneResponse}">
        /// A MainResponse containing information about the plane if found, 
        /// otherwise, a MainResponse with the appropriate error message.
        /// </returns>
        Task<MainResponse<PlaneResponse>> GetPlaneById(int id);

        /// <summary>
        /// Adds a new plane to the database.
        /// </summary>
        /// <param name="planeRequest">The details of the plane to be added.</param>
        /// <returns cref="MainResponse{PlaneResponse}">
        /// A MainResponse containing information about the newly added plane if successful, 
        /// otherwise, a MainResponse with the appropriate error message.
        /// </returns>
        Task<MainResponse<PlaneResponse>> AddPlane(PlaneRequest planeRequest);

        /// <summary>
        /// Updates an existing plane in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the plane to be updated.</param>
        /// <param name="planeRequest">The updated details of the plane.</param>
        /// <returns cref="MainResponse{PlaneResponse}">
        /// A MainResponse containing information about the updated plane if successful, 
        /// otherwise, a MainResponse with the appropriate error message.
        /// </returns>
        Task<MainResponse<PlaneResponse>> UpdatePlane(int id, PlaneRequest planeRequest);

        /// <summary>
        /// Deletes a plane from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the plane to be deleted.</param>
        /// <returns cref="MainResponse{bool}">
        /// A MainResponse indicating the success of the delete operation, 
        /// otherwise, a MainResponse with the appropriate error message.
        /// </returns>
        Task<MainResponse<bool>> DeletePlane(int id);

        /// <summary>
        /// Checks if a plane with the same attributes as the provided plane exists in the database.
        /// </summary>
        /// <param name="plane">The plane entity to compare against existing planes.</param>
        /// <returns cref="bool">
        /// True if a plane matching the provided criteria exists in the database, otherwise false.
        /// </returns>
        Task<bool> IsPlaneExists(PlaneEntity plane);
    }
}
