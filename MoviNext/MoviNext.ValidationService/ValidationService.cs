using MoviNext.Model;

namespace MoviNext.ValidationService
{
    public class ValidationService
    {
        public bool Validate(Steuerung steuerung)
        {
            throw new NotImplementedException();
        }

        UmrichterValidator umrichterVali = new UmrichterValidator();

        public bool Validate(Umrichter umrichter)
        {
            var result = umrichterVali.Validate(umrichter);

            return result.IsValid;
        }

        public bool Validate(Subkomponente subkomponente)
        {
            throw new NotImplementedException();
        }

    }
}