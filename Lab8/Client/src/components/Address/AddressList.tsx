import useRepository from "../../hooks/useRepository";
import { Address } from "../../models";

import { useEffect, useState } from 'react';
import { useNavigate } from "react-router-dom";

const modelName = 'address';

const AddressList = () => {
  const repository = useRepository<Address>(modelName);
  const [data, setData] = useState<Address[] | undefined>(undefined);
  const navigate = useNavigate();

  useEffect(() => {
    (async () => {
      const result = await repository.getAll();

      setData(result);
    })();
  }, []);

  const deleteAddress = async (id: number) => {
    await repository.delete(id);
    navigate('/' + modelName);
  };

  const content = (!data)
    ? <h2>Loading...</h2>
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
        {data?.map((model: Address) =>
          <tr key={model.id}>
            <td>
              {model.city}
            </td>
            <td>
              {model.street}
            </td>
            <td>
              {model.houseNumber}
            </td>
            <td>
              <button className='button yellow' onClick={() =>
                navigate('cuv', { state: { model, mode: 'edit' } })}>Edit</button>{" | "}
              <button className='button alert' onClick={async () => {
                await deleteAddress(model.id);
                setData(data.filter(i => i.id != model.id))
              }}>Delete</button>
            </td>
          </tr>
        )}
      </tbody>
    </table >

  return (
    <div>
      <h1>Address list</h1>
      <p>
        <button className='button success' onClick={() => navigate('cuv')}>Create New</button>
      </p>
      {content}
    </div>
  )
}

export default AddressList;