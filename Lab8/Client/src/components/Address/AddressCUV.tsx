import useRepository from "../../hooks/useRepository";
import { Address } from "../../models";
import { Link, useLocation, useNavigate, useNavigation } from "react-router-dom";

const modelName = 'address';

const AddressCUV = () => {
  const repository = useRepository<Address>(modelName);

  const { state } = useLocation();
  const mode: 'edit' | 'create' = state?.mode ?? 'create';
  const model: Address = state?.model ?? {};
  const navigate = useNavigate();

  async function submit(e: any) {
    e.preventDefault();

    if (mode === "create") {
      await repository.create({
        id: 0,
        city: e.target['city'].value as string,
        street: e.target['street'].value as string,
        houseNumber: e.target['houseNumber'].value - 0 as number,
        flatNumber: e.target['flatNumber'].value - 0 as number,
      });
    } else {
      await repository.update(model.id, {
        id: model.id,
        city: e.target['city'].value as string,
        street: e.target['street'].value as string,
        houseNumber: e.target['houseNumber'].value - 0 as number,
        flatNumber: e.target['flatNumber'].value - 0 as number,
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
      {createFor('city', 'City')}
      {createFor('street', 'Street')}
      {createFor('houseNumber', 'House Number', 'number')}
      {createFor('flatNumber', 'Flat Number', 'number')}
      {
        (mode == "create" || mode == "edit") ?
          <input style={{ width: '100px' }} className="button success" type="submit" data-role="submit"></input>
          : <></>
      }
    </form>
  );

  return (
    <div>
      <h1>Address {mode}</h1>
      {content}
      <p></p>
      <Link to={'/' + modelName} className="button success">Back to list</Link>
    </div>
  )
}

export default AddressCUV;