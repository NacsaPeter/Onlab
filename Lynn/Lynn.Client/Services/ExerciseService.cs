using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Client.Services
{
    public class ExerciseService: BaseHttpService
    {
        public async Task<ObservableCollection<VocabularyExercise>> GetVocabularyExercises(Test test)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/exercise"));

                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<VocabularyExercise>));
                var streamTask = client.GetStreamAsync($"{BaseUrl}/api/exercise/vocabulary/test/{test.ID}");
                return serializer.ReadObject(await streamTask) as ObservableCollection<VocabularyExercise>;
            }
        }

        public async Task<ObservableCollection<GrammarExercise>> GetGrammarExercises(Test test)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/exercise"));

                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<GrammarExercise>));
                var streamTask = client.GetStreamAsync($"{BaseUrl}/api/exercise/grammar/test/{test.ID}");
                return serializer.ReadObject(await streamTask) as ObservableCollection<GrammarExercise>;
            }
        }

        public async Task<ObservableCollection<RuleDto>> GetGrammarRules(int testId)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/exercise"));

                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<RuleDto>));
                var streamTask = client.GetStreamAsync($"{BaseUrl}/api/exercise/rule/test/{testId}");
                return serializer.ReadObject(await streamTask) as ObservableCollection<RuleDto>;
            }
        }

        public async Task<GrammarExercise> PostGrammarExerciseAsync(GrammarExercise grammarExercise)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/exercise"));

                HttpResponseMessage response = await client.PostAsJsonAsync("api/exercise/grammar", grammarExercise);
                if (response.IsSuccessStatusCode)
                {
                    var serializer = new DataContractJsonSerializer(typeof(GrammarExercise));
                    return serializer.ReadObject(await response.Content.ReadAsStreamAsync()) as GrammarExercise;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<bool> DeleteGrammarExerciseAsync(GrammarExercise grammarExercise)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/exercise"));

                HttpResponseMessage response = await client.DeleteAsync($"{BaseUrl}/api/exercise/grammar/{grammarExercise.Id}");
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<GrammarExercise> PutGrammarExerciseAsync(GrammarExercise grammarExercise)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/exercise"));

                HttpResponseMessage response = await client.PutAsJsonAsync("api/exercise/grammar", grammarExercise);
                if (response.IsSuccessStatusCode)
                {
                    var serializer = new DataContractJsonSerializer(typeof(GrammarExercise));
                    return serializer.ReadObject(await response.Content.ReadAsStreamAsync()) as GrammarExercise;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<VocabularyExercise> PostVocabularyExerciseAsync(VocabularyExercise vocabularyExercise)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/exercise"));

                HttpResponseMessage response = await client.PostAsJsonAsync("api/exercise/vocabulary", vocabularyExercise);
                if (response.IsSuccessStatusCode)
                {
                    var serializer = new DataContractJsonSerializer(typeof(VocabularyExercise));
                    return serializer.ReadObject(await response.Content.ReadAsStreamAsync()) as VocabularyExercise;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<bool> DeleteVocabularyExerciseAsync(VocabularyExercise vocabularyExercise)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/exercise"));

                HttpResponseMessage response = await client
                    .DeleteAsync($"{BaseUrl}/api/exercise/vocabulary/{vocabularyExercise.ID}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<VocabularyExercise> PutVocabularyExerciseAsync(VocabularyExercise vocabularyExercise)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/exercise"));

                HttpResponseMessage response = await client.PutAsJsonAsync("api/exercise/vocabulary", vocabularyExercise);
                if (response.IsSuccessStatusCode)
                {
                    var serializer = new DataContractJsonSerializer(typeof(VocabularyExercise));
                    return serializer.ReadObject(await response.Content.ReadAsStreamAsync()) as VocabularyExercise;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<RuleDto> PostRuleAsync(RuleDto rule)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/exercise"));

                HttpResponseMessage response = await client.PostAsJsonAsync("api/exercise/rule", rule);
                if (response.IsSuccessStatusCode)
                {
                    var serializer = new DataContractJsonSerializer(typeof(RuleDto));
                    return serializer.ReadObject(await response.Content.ReadAsStreamAsync()) as RuleDto;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<RuleDto> PutRuleAsync(RuleDto rule)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/exercise"));

                HttpResponseMessage response = await client.PutAsJsonAsync("api/exercise/rule", rule);
                if (response.IsSuccessStatusCode)
                {
                    var serializer = new DataContractJsonSerializer(typeof(RuleDto));
                    return serializer.ReadObject(await response.Content.ReadAsStreamAsync()) as RuleDto;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
