import useRepository from "../../hooks/useRepository";
import { Order } from "../../models";
import { Link, useLocation, useNavigate, useNavigation } from "react-router-dom";

const modelName = 'order';

const OrderCUV = () => {
  const repository = useRepository<Order>(modelName);

  const { state } = useLocation();
  const mode: 'edit' | 'create' = state?.mode ?? 'create';
  const model: Order = state?.model ?? {};
  const navigate = useNavigate();

  async function submit(e: any) {
    e.preventDefault();

    if (mode === "create") {
      await repository.create({
        id: 0,
        date: e.target['city'].value as string,
        clientId: e.target['city'].value as number,
      });
    } else {
      await repository.update(model.id, {
        id: model.id,
        date: e.target['date'].value as string,
        clientId: e.target['clientId'].value as number,
      });
    }

    navigate('/' + modelName);
  }

  const createFor = (field: string, label: string, type: 'text' | 'number' | 'email' | 'date' = 'text') => {
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
      {createFor('date', 'Date', 'date')}
      {createFor('clientId', 'Client Id')}
      {
        (mode == "create" || mode == "edit") ?
          <input style={{ width: '100px' }} className="button success" type="submit" data-role="submit"></input>
          : <></>
      }
    </form>
  );

  return (
    <div>
      <h1>Order {mode}</h1>
      {content}
      <p></p>
      <Link to={'/' + modelName} className="button success">Back to list</Link>
    </div>
  )
}

export default OrderCUV;