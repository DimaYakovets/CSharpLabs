import useRepository from "../../hooks/useRepository";
import { Address } from "../../models";

import { useEffect } from 'react';

const AddressList = () => {
    const { queryAll, deleteQuery } = useRepository<Address>();
  
    const deleteAddress = async (id: number) => {
      await deleteQuery.mutateAsync(id);
    };
  
    const content = queryAll.isLoading
      ? <h2>Loading...</h2>
      : queryAll.isError
        ? <h2>Error</h2>
        : <table className='table table-striped'>
          <thead>
            <tr>
              <th>City</th>
              <th>Street</th>
              <th>House Number</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {queryAll.data?.map((address: Address) =>
              <tr key={address.id}>
                <td>
                  {address.city}
                </td>
                <td>
                  {address.street}
                </td>
                <td>
                  {address.houseNumber}
                </td>
                <td>
                  {/* <button className='btn btn-warning' onClick={() => navigate('update', { state: address, replace: true })}>Edit</button>{" | "} */}
                  <button className='btn btn-danger' onClick={async () => await deleteAddress(address.id)}>Delete</button>
                </td>
              </tr>
            )}
          </tbody>
        </table>
  
    return (
      <>
        <h1>Index</h1>
        <p>
          {/* <Link to='create' className='btn btn-success'>Create New</Link> */}
        </p>
        {content}
      </>
    )
  }
  
  export default AddressList;