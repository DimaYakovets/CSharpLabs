import useRepository from "../../hooks/useRepository";
import { Client } from "../../models";

import { useEffect, useState } from 'react';
import { useNavigate } from "react-router-dom";

const modelName = 'client';

const ClientList = () => {
  const repository = useRepository<Client>(modelName);
  const [data, setData] = useState<Client[] | undefined>(undefined);
  const navigate = useNavigate();

  useEffect(() => {
    (async () => {
      const result = await repository.getAll();

      setData(result);
    })();
  }, []);

  const deleteClient = async (id: number) => {
    await repository.delete(id);
    navigate('/' + modelName);
  };

  const content = (!data)
    ? <h2>Loading...</h2>
    : <table className='table table-striped'>
      <thead>
        <tr>
          <th>Firstname</th>
          <th>Surname</th>
          <th>Patronymic</th>
          <th>Phone</th>
          <th>Address Id</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        {data?.map((model: Client) =>
          <tr key={model.id}>
            <td>{model.firstname}</td>
            <td>{model.surname}</td>
            <td>{model.patronymic}</td>
            <td>{model.phone}</td>
            <td>{model.addressId}</td>
            <td>
              <button className='button yellow' onClick={() =>
                navigate('cuv', { state: { model, mode: 'edit' } })}>Edit</button>{" | "}
              <button className='button alert' onClick={async () => {
                await deleteClient(model.id);
                setData(data.filter(i => i.id != model.id))
              }}>Delete</button>
            </td>
          </tr>
        )}
      </tbody>
    </table >

  return (
    <div>
      <h1>Client list</h1>
      <p>
        <button className='button success' onClick={() => navigate('cuv')}>Create New</button>
      </p>
      {content}
    </div>
  )
}

export default ClientList;