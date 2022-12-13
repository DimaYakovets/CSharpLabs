import useRepository from "../../hooks/useRepository";
import { Pizza } from "../../models";

import { useEffect, useState } from 'react';
import { useNavigate } from "react-router-dom";

const modelName = 'pizza';

const PizzaList = () => {
  const repository = useRepository<Pizza>(modelName);
  const [data, setData] = useState<Pizza[] | undefined>(undefined);
  const navigate = useNavigate();

  useEffect(() => {
    (async () => {
      const result = await repository.getAll();

      setData(result);
    })();
  }, []);

  const deletePizza = async (id: number) => {
    await repository.delete(id);
    navigate('/' + modelName);
  };

  const content = (!data)
    ? <h2>Loading...</h2>
    : <table className='table table-striped'>
      <thead>
        <tr>
          <th>Price</th>
          <th>Description</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        {data?.map((model: Pizza) =>
          <tr key={model.id}>
            <td>{model.price}</td>
            <td>{model.description}</td>
            <td>
              <button className='button yellow' onClick={() =>
                navigate('cuv', { state: { model, mode: 'edit' } })}>Edit</button>{" | "}
              <button className='button alert' onClick={async () => {
                await deletePizza(model.id);
                setData(data.filter(i => i.id != model.id))
              }}>Delete</button>
            </td>
          </tr>
        )}
      </tbody>
    </table >

  return (
    <div>
      <h1>Pizza list</h1>
      <p>
        <button className='button success' onClick={() => navigate('cuv')}>Create New</button>
      </p>
      {content}
    </div>
  )
}

export default PizzaList;