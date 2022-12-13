import useRepository from "../../hooks/useRepository";
import { Pizza } from "../../models";
import { Link, useLocation, useNavigate, useNavigation } from "react-router-dom";

const modelName = 'pizza';

const PizzaCUV = () => {
  const repository = useRepository<Pizza>(modelName);

  const { state } = useLocation();
  const mode: 'edit' | 'create' = state?.mode ?? 'create';
  const model: Pizza = state?.model ?? {};
  const navigate = useNavigate();

  async function submit(e: any) {
    e.preventDefault();

    if (mode === "create") {
      await repository.create({
        id: 0,
        description: e.target['description'].value as string,
        price: e.target['price'].value as number,
      });
    } else {
      await repository.update(model.id, {
        id: model.id,
        description: e.target['description'].value as string,
        price: e.target['price'].value as number,
      });
    }

    navigate('/' + modelName);
  }

  const createFor = (field: string, label: string, type: 'text' | 'number' | 'email' = 'text') => {
    const value: any = model && (model as any)[field];

    return <input type={type}
      name={field}
      value={value}
      data-role="input"
      data-prepend={label + ': '}></input>
  };

  const content = (
    <form onSubmit={submit}
      style={{ width: '400px', display: 'flex', flexDirection: 'column', gap: '8px' }}>
      {createFor('description', 'Description')}
      {createFor('price', 'Price', "number")}
      {
        (mode == "create" || mode == "edit") ?
          <input style={{ width: '100px' }} className="button success" type="submit" data-role="submit"></input>
          : <></>
      }
    </form>
  );

  return (
    <div>
      <h1>Pizza {mode}</h1>
      {content}
      <p></p>
      <Link to={'/' + modelName} className="button success">Back to list</Link>
    </div>
  )
}

export default PizzaCUV;