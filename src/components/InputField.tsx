import "./InputField.css"

interface Props{
  label:string
  value:any
  onChange:(e:any)=>void
  type?:string
  min?:number
}

export default function InputField({label,value,onChange,type="text"}:Props){

  return(

    <div className="input-field">

      <label>{label}</label>

      <input
        type={type}
        value={value}
        onChange={onChange}
      />

    </div>
    
  )
}