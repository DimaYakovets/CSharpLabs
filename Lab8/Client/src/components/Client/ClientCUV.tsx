import useRepository from "../../hooks/useRepository";
import { Client } from "../../models";
import { Link, useLocation, useNavigate, useNavigation } from "react-router-dom";

const modelName = 'client';

const ClientCUV = () => {
  const repository = useRepository<Client>(modelName);

  const { state } = useLocation();
  const mode: 'edit' | 'create' = state?.mode ?? 'create';
  const model: Client = state?.model ?? {};
  const navigate = useNavigate();

  async function submit(e: any) {
    e.preventDefault();

    if (mode === "create") {
      await repository.create({
        id: 0,
        firstname: e.target['firstname'].value as string,
        surname: e.target['surname'].value as string,
        phone: e.target['phone'].value as string,
        patronymic: e.target['patronymic'].value as string,
        addressId: e.target['addressId'].value as number,
      });
    } else {
      await repository.update(model.id, {
        id: model.id,
        firstname: e.target['firstname'].value as string,
        surname: e.target['surname'].value as string,
        phone: e.target['phone'].value as string,
        patronymic: e.target['patronymic'].value as string,
        addressId: e.target['addressId'].value as number,
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
      {createFor('firstname', 'Firstname')}
      {createFor('surname', 'Surname')}
      {createFor('phone', 'Phone')}
      {createFor('patronymic', 'Patronymic')}
      {createFor('addressId', 'Address Id', 'number')}
      {
        (mode == "create" || mode == "edit") ?
          <input style={{ width: '100px' }} className="button success" type="submit" data-role="submit"></input>
          : <></>
      }
    </form>
  );

  return (
    <div>
      <h1>Client {mode}</h1>
      {content}
      <p></p>
      <Link to={'/' + modelName} className="button success">Back to list</Link>
    </div>
  )
}

export default ClientCUV;